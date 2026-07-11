using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using Reflection.Presentation.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class TSK_T001_C_Bulk_VM : WorkspaceViewModel<TSK_T001_C> 
    {
        bool isNewRecord = true;
        WebServiceRepository<List<TSK_T001_C>> repository = new WebServiceRepository<List<TSK_T001_C>>();
        WebServiceRepository<MultipleContext_TSK_T001_C_Bulk> repository_MC = new WebServiceRepository<MultipleContext_TSK_T001_C_Bulk>();
        WebServiceRepository<MultipleContext_TSK_T001_C_Bulk> repository_MCTemp = new WebServiceRepository<MultipleContext_TSK_T001_C_Bulk>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(TSK_T001_C_Bulk_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASParentActivity { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParentActivity
        {
            get { return _ASParentActivity; }
            set
            {
                if (_ASParentActivity != value)
                {
                    _ASParentActivity = value; RaisePropertyChanged("ASParentActivity");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSalesInqNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesInqNo
        {
            get { return _ASSalesInqNo; }
            set
            {
                if (_ASSalesInqNo != value)
                {
                    _ASSalesInqNo = value; RaisePropertyChanged("ASSalesInqNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASOwner { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOwner
        {
            get { return _ASOwner; }
            set
            {
                if (_ASOwner != value)
                {
                    _ASOwner = value; RaisePropertyChanged("ASOwner");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
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

        private AutoSuggestTextViewModel<dynamic> _ASContactPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASContactPerson
        {
            get { return _ASContactPerson; }
            set
            {
                if (_ASContactPerson != value)
                {
                    _ASContactPerson = value; RaisePropertyChanged("ASContactPerson");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSalesPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesPerson
        {
            get { return _ASSalesPerson; }
            set
            {
                if (_ASSalesPerson != value)
                {
                    _ASSalesPerson = value; RaisePropertyChanged("ASSalesPerson");
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
                    if (SourceName == "parent_activity")
                    { ASDefault = ASParentActivity; }
                    else if (SourceName == "sono")
                    { ASDefault = ASSalesInqNo; }
                    else if (SourceName == "PartyId")
                    { ASDefault = ASParty; }
                    else if (SourceName == "contact_person")
                    { ASDefault = ASContactPerson; }
                }
            }
        }

        #endregion

        #region Declarations       
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        List<TSK_T001_C> RequestList = new List<TSK_T001_C>();

        private TSK_T001_C _ItemEntityObject;
        public TSK_T001_C ItemEntityObject
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
        private MultipleContext_TSK_T001_C_Bulk _MC;
        public MultipleContext_TSK_T001_C_Bulk MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_TSK_T001_C_Bulk _MCTemp;
        public MultipleContext_TSK_T001_C_Bulk MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_TSK_T001_C_Bulk _MCTemp1;
        public MultipleContext_TSK_T001_C_Bulk MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private MultipleContext_TSK_T001_C_Bulk _MCTemp2;
        public MultipleContext_TSK_T001_C_Bulk MCTemp2
        {
            get { return _MCTemp2; }
            set { _MCTemp2 = value; RaisePropertyChanged("MCTemp2"); }
        }

        private MultipleContext_TSK_T001_C_Bulk _MCTemp3;
        public MultipleContext_TSK_T001_C_Bulk MCTemp3
        {
            get { return _MCTemp3; }
            set { _MCTemp3 = value; RaisePropertyChanged("MCTemp3"); }
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

        private TSK_T001_C _MasterEntity;
        public TSK_T001_C MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
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

        private Nullable<System.DateTime> _SearchFromDate;
        public Nullable<System.DateTime> SearchFromDate
        {
            get
            {
                return _SearchFromDate;
            }
            set
            {
                _SearchFromDate = value;
                RaisePropertyChanged("_SearchFromDate");
            }
        }

        private Nullable<System.DateTime> _SearchToDate;
        public Nullable<System.DateTime> SearchToDate
        {
            get
            {
                return _SearchToDate;
            }
            set
            {
                _SearchToDate = value;
                RaisePropertyChanged("_SearchToDate");
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<TSK_T001_C> _BulkActivityCollection;
        public ObservableCollection<TSK_T001_C> BulkActivityCollection
        {
            get { return _BulkActivityCollection; }
            set
            {
                if (_BulkActivityCollection != value)
                {
                    _BulkActivityCollection = value;
                    BulkActivityCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterValue);
                    RaisePropertyChanged("BulkActivityCollection");
                }
            }
        }

        private List<TSK_T001_C> _SelectedList;
        public List<TSK_T001_C> SelectedList
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

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (BulkActivityCollection.Count > dgSelectedIndex && dgSelectedIndex >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForMasterValue(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (TSK_T001_C item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (TSK_T001_C item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (TSK_T001_C item in e.NewItems)
                    {
                        item.Click = true;
                        item.client = AppSessionState.client;
                        item.start_date = System.DateTime.Now;
                        item.owner = AppSessionState.EmpId;
                        item.EmpNameDisplay = AppSessionState.EmpName;
                        item.active = true;
                        item.act_action = "Log";
                        item.action_type = "Meeting";
                        item.doc_type = "LM";
                        item.doc_cat = "LM";
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.so_code = AppSessionState.so_code;
                        item.sg_code = AppSessionState.sg_code; 
                        item.doc_date = System.DateTime.Now;
                        item.t_status = "Working";
                        isNewRecord = true;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Relay Commands Declaration       

        public RelayCommand<object> cmdInsertParentActivity { get; private set; }
        public RelayCommand<object> cmdInsertSalesInqNo { get; private set; }
        public RelayCommand<object> cmdInsertOwner { get; private set; }
        public RelayCommand<object> cmdInsertParty { get; private set; }
        public RelayCommand<object> cmdInsertContactPerson { get; private set; }
        public RelayCommand<object> cmdLoad { get; private set; }
        public RelayCommand<object> cmdInsertSalesPerson { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDetail { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_TASK { get; private set; }

        #endregion

        #region Constructor
        public TSK_T001_C_Bulk_VM() : base()
        {
            MasterEntity = new TSK_T001_C();
            BulkActivityCollection = new ObservableCollection<TSK_T001_C>();

            MC = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp1 = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp2 = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp3 = new MultipleContext_TSK_T001_C_Bulk();

          //  TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            cmdInsertParentActivity = new RelayCommand<object>(items => { if (items == null) { return; } InsertParentActivity(items, true, true, true); });
            cmdInsertParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, true, true, true); });      
            cmdInsertSalesInqNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items, true, true, true); });
            cmdInsertSalesPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            cmdInsertContactPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items, true, true, true); });
            cmdLoad = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadData(cmdPara); });
            cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });
            cmdSelectionChanged_TASK = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChangeTask(cmdPara); });

            LoadInitialData();
        }
        public TSK_T001_C_Bulk_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new TSK_T001_C();
            BulkActivityCollection = new ObservableCollection<TSK_T001_C>();

            MC = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp1 = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp2 = new MultipleContext_TSK_T001_C_Bulk();
            MCTemp3 = new MultipleContext_TSK_T001_C_Bulk();

            //  TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            cmdInsertParentActivity = new RelayCommand<object>(items => { if (items == null) { return; } InsertParentActivity(items, true, true, true); });
            cmdInsertParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, true, true, true); });
            cmdInsertSalesInqNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items, true, true, true); });
            cmdInsertSalesPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            cmdInsertContactPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items, true, true, true); });
            cmdLoad = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadData(cmdPara); });
            cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });
            cmdSelectionChanged_TASK = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChangeTask(cmdPara); });
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + (MasterEntity.comp_code ?? AppSessionState.comp_code) + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C_Bulk>(MC, Request, "CRM_ActivityBulk", "CRM", "LoadInitialData", 0, "");

                DefaultValues();

                BulkActivityCollection = MC.BulkActivityEntity;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((TSK_T001_C_P)x).doc_no);
                TheFilter = (o, prefix) => (((TSK_T001_C_P)o).doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.SheduleNumber, TheFilter, SuggestedValue, "parent_activity", "doc_no", false);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((TSK_T001_C_P)x).doc_no);
                TheFilter = (o, prefix) => (((TSK_T001_C_P)o).doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParentActivity = new AutoSuggestTextViewModel<dynamic>(MC.SheduleNumber, TheFilter, SuggestedValue, "parent_activity", "doc_no", false);
                ASParentActivity.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASParentActivity.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", "PartyId", false);
                ASParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "owner", "EmpId", false);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASEmployee.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalesPerson= new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "owner", "EmpId", false);
                ASSalesPerson.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSalesPerson.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalesInqNo = new AutoSuggestTextViewModel<dynamic>(MC.SalesInquiryMaster, TheFilter, SuggestedValue, "sono", "sono", false);
                ASSalesInqNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSalesInqNo.AutoSuggestVM.IsFreeTextAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var locationMaster = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(locationMaster, TheFilter, SuggestedValue, "location_Id", "location_Id", false);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).PersonName.ToString());
                TheFilter = (o, prefix) => (((ADM_M028_D_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MC.ContactInfo, TheFilter, SuggestedValue, "contact_person", "PersonName", true);
                ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;
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
                if (RequestList != null && RequestList.Count > 0)
                {
                    foreach (var item in RequestList)
                    {
                        if (item.act_action == "Log" && item.action_type == "Meeting")
                        {
                            item.doc_type = "LM";
                            item.doc_cat = "LM";
                        }

                        else if (item.act_action == "Schedule" && item.action_type == "Meeting")
                        {
                            item.doc_type = "SM";
                            item.doc_cat = "SM";
                        }

                        if (item.act_action == "Log" && item.action_type == "Call")
                        {
                            item.doc_type = "LC";
                            item.doc_cat = "LC";
                        }

                        else if (item.act_action == "Schedule" && item.action_type == "Call")
                        {
                            item.doc_type = "SC";
                            item.doc_cat = "SC";
                        }

                        if (item.add_by == null || item.add_by == "")
                        {
                            item.add_by = AppSessionState.UserID;
                        }
                        item.editby = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.so_code = AppSessionState.so_code;
                        item.sg_code = AppSessionState.sg_code;
                        item.client = AppSessionState.client;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.userid = AppSessionState.UserID;
                        item.ts_code = ts_code_vm;

                        if (item.doc_date == null)
                        {
                            item.doc_date = System.DateTime.Now;
                        }

                        if (item.start_date == null)
                        {
                            item.start_date = System.DateTime.Now;
                        }

                        if (item.owner == null || item.owner == "")
                        {
                            item.owner = AppSessionState.EmpId;
                        }
                        //if (item.EmpName == null || item.EmpName == "")
                        //{
                            item.EmpNameDisplay  = AppSessionState.EmpName;
                        //}
                        if (item.active == null)
                        {
                            item.active = true;
                        }
                        if (item.t_status == null)
                        {
                            item.t_status = "Working";
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
        private bool Validation()
        {
            try
            {
                if (RequestList != null)
                {
                    foreach (var o in RequestList)
                    {
                        if (o.action_type == null || o.action_type == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Action Type Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.act_action == null || o.act_action == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Activity Action Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.doc_date == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Document Date Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        //if (o.start_date == null)
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Start Date Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}                      
                        if (o.owner == null || o.owner == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Employee Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.party_name == null || o.party_name == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Party Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        //if (o.priority == null || o.priority == "")
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Priority Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                        //if (o.from_time == null || o.from_time == "")
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Start Time Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                        if (o.contact_person == null || o.contact_person == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Contact Person Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        //if (o.t_status == null || o.t_status == "")
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Status Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                        if (o.EmailId == null || o.EmailId == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Email_Id Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        //if (o.project_name == null || o.project_name == "")
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Project Name Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                        //if (o.project_location == null || o.project_location == "")
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Required";
                        //    showMessageService.Text = String.Format("Project Location Is Required", this.Title);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                    }
                    return true;
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
        //void ModelUpdated_Master(object sender, EventArgs e)
        //{
        //    //This will get called when the property of an object inside the collection changes

        //    if (sender.ToString() == "from_time" || sender.ToString() == "to_time")
        //    {

        //        if (MasterEntity.to_time != null)
        //        {
        //            if (MasterEntity.from_time != null)
        //            {
        //                TimeSpan duration1 = DateTime.Parse(MasterEntity.to_time).Subtract(DateTime.Parse(MasterEntity.from_time));

        //                MasterEntity.duration = (duration1).ToString();

        //            }
        //        }

        //    }
        //    this.ErrorExist = MasterEntity.HasErrors;

        //}

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MCTemp3.BulkActivityEntity != null && MCTemp3.BulkActivityEntity.Count > 0)
                {  
                    BulkActivityCollection = MC.BulkActivityEntity;
                }
                else
                {
                    MC.BulkActivityEntity = new ObservableCollection<TSK_T001_C>();
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

        #region Functions for Pop_Ups
        private void SelectionChangeTask(object InputValue)
        {
            try
            {
                ItemEntityObject = (TSK_T001_C)InputValue;
            }
            catch (Exception ex) { }
        }
        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (BulkActivityCollection.Count > i && ItemEntityObject != null)
                {
                    if(ItemEntityObject.id == 0)
                    {
                        BulkActivityCollection.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {}
        }
        private void InsertParentActivity(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                TSK_T001_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SheduleNumber.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<TSK_T001_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {

                    Request = "LoadDocWithParentActNo" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + POPUPEntityObject.doc_no;
                    TSK_T001_C ActivityObject = new TSK_T001_C();
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<List<TSK_T001_C>>(MCTemp, Request, "CRM_ActivityBulk", "CRM", "LoadDocWithParentActNo", 0, "");

                    if (MCTemp.BulkActivityEntity != null)
                    { 
                        if(MCTemp.BulkActivityEntity.Count > 0)
                        {
                            ActivityObject = MCTemp.BulkActivityEntity[0];
                            ItemEntityObject.client = AppSessionState.client;
                            ItemEntityObject.comp_code = AppSessionState.comp_code;
                            ItemEntityObject.location_Id = AppSessionState.location_Id;
                            ItemEntityObject.parent_activity = ActivityObject.doc_no;
                            ItemEntityObject.active = true;
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
        private void InsertParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ItemEntityObject.PartyId = POPUPEntityObject.PartyId;
                    ItemEntityObject.party_name = POPUPEntityObject.PartyNm;

                    Request = "LoadPartyDetail" + "!@" + ItemEntityObject.PartyId + "!@" + AppSessionState.client + "!@" + (ItemEntityObject.comp_code ?? AppSessionState.comp_code);
                    MCTemp1 = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C_Bulk>(MCTemp1, Request, "CRM_ActivityBulk", "CRM", "LoadPartyDetail", 0, "");
                    if (MCTemp1.ContactInfo.Count > 0 && MCTemp1.ContactInfo != null)
                    {
                        LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var locationMaster = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                        TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        ASLocation = new AutoSuggestTextViewModel<dynamic>(locationMaster, TheFilter, SuggestedValue, "location_Id", "location_Id", false);

                        ItemEntityObject.contact_person = null;
                        ItemEntityObject.person_number = null;
                        ItemEntityObject.EmailId = null;
                        ItemEntityObject.place = null;
                        ItemEntityObject.address = null;
                        ItemEntityObject.architect_grade = null;
                        ItemEntityObject.action_type = "Meeting";
                        ItemEntityObject.act_action = "Schedule";

                        // Filtering Contact Person Based On Item Code/Product Code selection

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).PersonName.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp1.ContactInfo, TheFilter, SuggestedValue, "contact_person", "PersonName", false);
                        ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void InsertSales(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesInquiryMaster.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemEntityObject.sono = POPUPEntityObject.sono;
                    ItemEntityObject.s_status = POPUPEntityObject.t_status;
                    ItemEntityObject.project_name = POPUPEntityObject.para3;
                    ItemEntityObject.project_type = POPUPEntityObject.reference;
                    ItemEntityObject.project_location = POPUPEntityObject.project_location;
                    ItemEntityObject.PartyId = POPUPEntityObject.PartyId;
                    ItemEntityObject.party_name = POPUPEntityObject.party_name;
                    ItemEntityObject.start_date = System.DateTime.Now;
                    ItemEntityObject.owner = AppSessionState.EmpId;
                    ItemEntityObject.EmpNameDisplay = AppSessionState.EmpName;
                }
                if (ItemEntityObject.PartyId != null && ItemEntityObject.PartyId != "")
                {
                    Request = "LoadPartyDetail" + "!@" + ItemEntityObject.PartyId;
                    MCTemp1 = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C_Bulk>(MCTemp1, Request, "CRM_ActivityBulk", "CRM", "LoadPartyDetail", 0, "");

                    if (MCTemp1.ContactInfo != null)
                    {
                        if (MCTemp1.ContactInfo.Count > 0)
                        {
                            LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                            var locationMaster = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                            TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASLocation = new AutoSuggestTextViewModel<dynamic>(locationMaster, TheFilter, SuggestedValue, "location_Id", "location_Id", false);

                            ItemEntityObject.contact_person = MCTemp1.ContactInfo[0].PersonName;
                            ItemEntityObject.person_number = MCTemp1.ContactInfo[0].PersnMobNo;
                            ItemEntityObject.EmailId = MCTemp1.ContactInfo[0].PersnEmailId;
                            ItemEntityObject.place = MCTemp1.ContactInfo[0].Location;
                            ItemEntityObject.address = MCTemp1.ContactInfo[0].Add1;
                            ItemEntityObject.architect_grade = MCTemp1.ContactInfo[0].group1;
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

        private void InsertContactPerson(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_D_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp1.ContactInfo.Where(x => x.PersonName.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_D_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemEntityObject.contact_person = POPUPEntityObject.PersonName;
                    ItemEntityObject.person_number = POPUPEntityObject.PersnMobNo;
                    ItemEntityObject.EmailId = POPUPEntityObject.PersnEmailId;
                    ItemEntityObject.place = POPUPEntityObject.Location;
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

        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FromDate", SearchFromDate.ToString());
                result.Add("ToDate", SearchToDate.ToString());
                //result.Add("PartyId", ReportParameters.PartyId);
                //result.Add("PartyNm", ReportParameters.PartyNm);
                //result.Add("EmpName", ReportParameters.EmpName);
                //result.Add("doc_type", ReportParameters.doc_type);
                //result.Add("doc_cat", ReportParameters.doc_cat);
                //result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", "Activity Report");
                //result.Add("doc_no", ReportParameters.doc_no);
                result.Add("comp_code", AppSessionState.CompanyName);
                //result.Add("Location_Id", ReportParameters.Location_Id);
                //result.Add("act_action", ReportParameters.act_action);
                //result.Add("action_type", ReportParameters.action_type);
                //result.Add("PartyType", ReportParameters.PartyType);
                //result.Add("StatusName", ReportParameters.StatusName);
                //result.Add("group1", ReportParameters.group1);
                //result.Add("prospectus", ReportParameters.prospectus);

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
        #endregion


        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<TSK_T001_C> result)
        {
            isNewRecord = true;
            MasterEntity = new TSK_T001_C();
            BulkActivityCollection  = new ObservableCollection<TSK_T001_C>();
            DefaultValues();
        }
        protected override void OnPrintAction(InquiryActionResult<TSK_T001_C> result)
        {
            try
            {
                object[] objDataSource = new object[1];
                string[] objDataSourceName = new string[1];
                objDataSource[0] = BulkActivityCollection;
                objDataSourceName[0] = "dsMIS_CRM_Sales2";
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Activity.rdlc", getParametersList(), "Activity");
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
        protected override void OnRefreshCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }
        //protected override void OnSaveAction(InquiryActionResult<TSK_T001_C> result)
        //{
        //    try
        //    {    
        //        RequestList.Clear();
        //        foreach (TSK_T001_C item in BulkActivityCollection)
        //        { 
        //            if (item.Click == true)
        //            {
        //                RequestList.Add(item);
        //            }
        //        }

        //        DefaultValues();

        //        if (Validation() == true && RequestList !=null && RequestList.Count > 0)
        //        {

        //            string strReturn = repository.Save<List<TSK_T001_C>>(RequestList, "CRM_ActivityBulk", "CRM");
        //            RequestList = repository.SaveWithReturnDomainObject<List<TSK_T001_C>>(RequestList, "CRM_ActivityBulk", "CRM");

        //            //if (RequestList != null && RequestList.Count >0)
        //            //{
        //            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            //    showMessageService.ButtonSetup = DialogButton.Ok;
        //            //    showMessageService.Caption = "Message";
        //            //    showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
        //            //    showMessageService.ShowMessage();

        //            //    BulkActivityCollection.Clear();

        //            //    foreach (var o in RequestList)
        //            //    {
        //            //        BulkActivityCollection.Add(o);
        //            //    }
        //            //}

        //            if (strReturn != "" && strReturn != null)
        //            {
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
        //                showMessageService.ShowMessage();

        //                if (RequestList != null && RequestList.Count > 0)
        //                {
        //                    foreach (var o in RequestList)
        //                    {
        //                        BulkActivityCollection.Remove(o);
        //                    }
        //                }
        //            }
        //        }
        //        if (RequestList == null || RequestList.Count <= 0)
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Please select the row to Save or Update Records", this.Title);
        //            showMessageService.ShowMessage();
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

        protected override void OnSaveAction(InquiryActionResult<TSK_T001_C> result)
        {
            try
            {
                RequestList.Clear();
                foreach (TSK_T001_C item in BulkActivityCollection)
                {
                    if (item.Click == true)
                    {
                        RequestList.Add(item);
                    }
                }
                //DefaultValues();

                if (Validation() == true && RequestList != null && RequestList.Count > 0)
                {
                    RequestList = repository.SaveWithReturnDomainObject<List<TSK_T001_C>>(RequestList, "CRM_ActivityBulk", "CRM");

                    if (RequestList != null && RequestList.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();

                        BulkActivityCollection.Clear();

                        foreach (var o in RequestList)
                        {
                            BulkActivityCollection.Add(o);
                        }
                    }

                }
                if (RequestList == null || RequestList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select the row to Save or Update Records", this.Title);
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
        protected override void OnRemoveAction(InquiryActionResult<TSK_T001_C> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<TSK_T001_C> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<TSK_T001_C> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<TSK_T001_C> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<TSK_T001_C> result)
        { }
        #endregion

        #region Filters

        private void LoadData(object InputValue)
        {
            try
            {
                if (MasterEntity.owner != null && MasterEntity.owner != "" && SearchFromDate !=null && SearchToDate !=null)
                { 
                string Request = "LoadData" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.location_Id + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(SearchFromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SearchToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.owner;
                MCTemp2 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C_Bulk>(MCTemp2, Request, "CRM_ActivityBulk", "CRM", "LoadData", 0, "");

                BulkActivityCollection = MCTemp2.BulkActivityEntity;
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select \n 1. Sales Person \n 2.From Date \n 3. To Date", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex) { }
        }

        private void InsertEmployee(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.EmployeeMaster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.owner = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;

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

        

        //#region Filters Collection

        //private string _filterString_DataGrid;
        //public string FilterString_DataGrid
        //{
        //    get { return _filterString_DataGrid; }
        //    set
        //    {
        //        _filterString_DataGrid = value;
        //        RaisePropertyChanged("FilterString_DataGrid");
        //        FilterCollection();
        //    }
        //}
        //private void FilterCollection()
        //{
        //    if (_BulkActivityCollection != null)
        //    {
        //        foreach (var item in BulkActivityCollection)
        //        {
        //            item.ad
        //        }
        //    }
        //}
        //public bool Filter(object obj)
        //{
        //    var data = obj as TSK_T001_C;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString_DataGrid))
        //        {
        //            return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
        //                   (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_DataGrid.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        #endregion
        #endregion
    }
}
