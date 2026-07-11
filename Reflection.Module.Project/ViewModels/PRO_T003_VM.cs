using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.VirtualDesktops;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Module.Project.ViewModels
{
    class PRO_T003_VM : WorkspaceViewModel<PRO_T003>
    {
        #region AutoSuggest TextBox Declaration Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T001_INQ_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }


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

        private AutoSuggestTextViewModel<dynamic> _ASProject { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProject
        {
            get { return _ASProject; }
            set
            {
                if (_ASProject != value)
                {
                    _ASProject = value; RaisePropertyChanged("ASProject");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPhase { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPhase
        {
            get { return _ASPhase; }
            set
            {
                if (_ASPhase != value)
                {
                    _ASPhase = value; RaisePropertyChanged("ASPhase");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAssignedTo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAssignedTo
        {
            get { return _ASAssignedTo; }
            set
            {
                if (_ASAssignedTo != value)
                {
                    _ASAssignedTo = value; RaisePropertyChanged("ASAssignedTo");
                }
            }
        }

       
        private AutoSuggestTextViewModel<dynamic> _ASDoneBy { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDoneBy
        {
            get { return _ASDoneBy; }
            set
            {
                if (_ASDoneBy != value)
                {
                    _ASDoneBy = value; RaisePropertyChanged("ASDoneBy");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTask{ get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTask
        {
            get { return _ASTask; }
            set
            {
                if (_ASTask != value)
                {
                    _ASTask = value; RaisePropertyChanged("ASTask");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASReporterName{ get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReporterName
        {
            get { return _ASReporterName; }
            set
            {
                if (_ASReporterName != value)
                {
                    _ASReporterName = value; RaisePropertyChanged("ASReporterName");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIssueCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIssueCategory
        {
            get { return _ASIssueCategory; }
            set
            {
                if (_ASIssueCategory != value)
                {
                    _ASIssueCategory = value; RaisePropertyChanged("ASIssueCategory");
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

                    if (SourceName == "done_by")
                    { ASDefault = ASDoneBy; }

                }
            }

        }

        #endregion

        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<MultipleContext_PRO_T003> repository_MC = new WebServiceRepository<MultipleContext_PRO_T003>();
        WebServiceRepository<PRO_T003> repository = new WebServiceRepository<PRO_T003>();
        MultipleContext_PRO_T003 _MC = new MultipleContext_PRO_T003();
        MultipleContext_PRO_T003 MC_temp = new MultipleContext_PRO_T003();

        bool NewRecord = true;
        int ActionLogEntityCount;
        public MultipleContext_PRO_T003 MC
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

        private PRO_T003 _MasterEntity;
        public PRO_T003 MasterEntity
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

        private int _dgSelectedIndexAction;
        public int dgSelectedIndexAction
        {
            get { return _dgSelectedIndexAction; }
            set
            {
                if (_dgSelectedIndexAction != null)
                {
                    _dgSelectedIndexAction = value;
                    RaisePropertyChanged("dgSelectedIndexAction");

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

        private ObservableCollection<PRO_T003_A> _ActionLogEntity;
        public ObservableCollection<PRO_T003_A> ActionLogEntity
        {
            get { return _ActionLogEntity; }
            set
            {
                if (_ActionLogEntity != value)
                {
                    _ActionLogEntity = value;
                    RaisePropertyChanged("ActionLogEntity");
                }
            }
        }

        private List<PRO_T003_View> _DataGridCollection = new List<PRO_T003_View>();
        public List<PRO_T003_View> DataGridCollection
        {
            get { return _DataGridCollection; }
            set
            {
                if (_DataGridCollection != value)
                {
                    _DataGridCollection = value;
                    RaisePropertyChanged("DataGridCollection");
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
        #endregion

        #region ICollectionView

        private ICollectionView _IssueCollection;
        public ICollectionView IssueCollection
        {
            get { return _IssueCollection; }
            set
            {
                _IssueCollection = value;
                RaisePropertyChanged("IssueCollection");
            }

        }

        #endregion


        #region StringList Variables

        private List<string> _StrListPrjName;
        public List<string> StrListPrjName
        {
            get { return _StrListPrjName; }
            set
            {
                if (_StrListPrjName != value)
                {
                    _StrListPrjName = value;                 
                }
            }
        }

        private List<string> _strListPhase;
        public List<string> StrListPhase
        {
            get { return _strListPhase; }
            set
            {
                if (_strListPhase != value)
                {
                    _strListPhase = value;
                }
            }
        }

        private List<string> _strListAssginedTo;
        public List<string> StrListAssginedTo
        {
            get { return _strListAssginedTo; }
            set
            {
                if (_strListAssginedTo != value)
                {
                    _strListAssginedTo = value;
                }
            }
        }

        private List<string> _strListReporterName;
        public List<string> StrListReporterName
        {
            get { return _strListReporterName; }
            set
            {
                if (_strListReporterName != value)
                {
                    _strListReporterName = value;
                }
            }
        }

        private List<string> _strListDoneby;
        public List<string> StrListDoneby
        {
            get { return _strListDoneby; }
            set
            {
                if (_strListDoneby != value)
                {
                    _strListDoneby = value;
                }
            }
        }

        private List<string> _strListTasks;
        public List<string> StrListTasks
        {
            get { return _strListTasks; }
            set
            {
                if (_strListTasks != value)
                {
                    _strListTasks = value;
                }
            }
         }


        private List<string> _strListIssueCategories;
        public List<string> StrListIssueCategories
        {
            get { return _strListIssueCategories; }
            set
            {
                if (_strListIssueCategories != value)
                {
                    _strListIssueCategories = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> cmdProject { get; private set; }
        public RelayCommand<object> cmdPhase { get; private set; }
        public RelayCommand<object> cmdTask{ get; private set; }
        public RelayCommand<object> cmdAssignedTo { get; private set; }    
        public RelayCommand<object> cmdDoneByEmp { get; private set; }
        public RelayCommand<object> cmdReporterName { get; private set; }
        public RelayCommand<object> cmdIssueCategory { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridActionLog{ get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNo { get; private set; }

        public GalaSoft.MvvmLight.Command.RelayCommand cmdViewIssueTimesheet { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public PRO_T003_VM(string ts_code) : base()
        {
            MasterEntity = new PRO_T003();
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_PRO_T003();
            ActionLogEntity = new ObservableCollection<PRO_T003_A>();

            DefaultValues();

            MasterEntity.ValidateAsync().Wait();

            PRO_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ActionSummary);

            #region Command Initialisation

            cmdProject = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectName(items); });
            cmdPhase = new RelayCommand<object>(items => { if (items == null) { return; } InsertPhase(items); });         
            cmdTask = new RelayCommand<object>(items => { if (items == null) { return; } InsertTask(items); });
            cmdAssignedTo = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignedTo(items); });
            cmdReporterName = new RelayCommand<object>(items => { if (items == null) { return; } InsertReporterName(items); });
            cmdIssueCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertIssueCategory(items); });

            cmdDoneByEmp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDoneByEmp(cmdPara, false, true, true); });
            cmdDeleteDataGridActionLog = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ActionLog(cmdPara); });

            cmdLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNo(cmdPara, "FlipGridReference"); });                   
            cmdViewIssueTimesheet = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewIssueTimesheet(); });

            #endregion

            LoadInitialData();
            

        }
        public PRO_T003_VM(string ts_code,string doc_no) : base()
        {
            MasterEntity = new PRO_T003();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_PRO_T003();
            ActionLogEntity = new ObservableCollection<PRO_T003_A>();

            DefaultValues();

            MasterEntity.ValidateAsync().Wait();

            PRO_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ActionSummary);

            LoadInitialData();
            //if (AppSessionState.TransValue != null)
            //{
            //    LoadDocumentByDocumentNo(AppSessionState.TransValue, "DocumentNo");
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        #endregion

        #region User Defined Methods and Relay Command Methods
        private void DefaultValues()
        {
            try
            {
                MasterEntity.doc_cat = "IS";
                MasterEntity.doc_type = "IS";
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = "004";
                MasterEntity.doc_date = DateTime.UtcNow;
                MasterEntity.facing_from_date = DateTime.UtcNow;
                MasterEntity.reporting_date = DateTime.UtcNow;             
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

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "IS" + "!@" + "IS" + "!@" + (MasterEntity.issue_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                //string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T003>(MC, Request, "Issues", "PM", "LoadAll", 0, "");

                #region Command Initialisation

                cmdProject = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectName(items); });
                cmdPhase = new RelayCommand<object>(items => { if (items == null) { return; } InsertPhase(items); });
                cmdTask = new RelayCommand<object>(items => { if (items == null) { return; } InsertTask(items); });
                cmdAssignedTo = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignedTo(items); });
                cmdReporterName = new RelayCommand<object>(items => { if (items == null) { return; } InsertReporterName(items); });
                cmdIssueCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertIssueCategory(items); });

                cmdDoneByEmp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDoneByEmp(cmdPara, false, true, true); });
                cmdDeleteDataGridActionLog = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ActionLog(cmdPara); });

                cmdLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNo(cmdPara, "FlipGridReference"); });
                cmdViewIssueTimesheet = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewIssueTimesheet(); });

                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                #region AutoSuggest Initialisation

                //Project List
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_P)x).project_id);
                TheFilter = (o, prefix) => (((PRO_T001_P)o).project_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_P)o).project_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.ProjectList, TheFilter, SuggestedValue, "project_id", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Reporter Name               
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReporterName = new AutoSuggestTextViewModel<dynamic>(MC.ReporterNameList, TheFilter, SuggestedValue, "EmpId", true);
                ASReporterName.AutoSuggestVM.IsEmptyValueAllowed = true;

                StrListPrjName = MC.ProjectList.Select(x => x.project_id).ToList();

                StrListReporterName = MC.ReporterNameList.Select(x => x.EmpLName).ToList();

                //Work Done By List
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.WorkDoneByList, TheFilter, SuggestedValue, "done_by", "EmpId", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M001_P)x).cat_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M001_P)o).cat_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M001_P)o).cat_title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASIssueCategory  = new AutoSuggestTextViewModel<dynamic>(MC.IssueCategoryList, TheFilter, SuggestedValue, "cat_id", true);
                ASIssueCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                StrListIssueCategories = MC.IssueCategoryList.Select(x => x.cat_id.ToString()).ToList();

                #endregion


                DataGridCollection = MC.IssueViewList ;
                IssueCollection  = CollectionViewSource.GetDefaultView(DataGridCollection);

                
                IssueCollection = CollectionViewSource.GetDefaultView(DataGridCollection);
                IssueCollection.Filter = new Predicate<object>(FilterIssues);


                if (AppSessionState.TransValueType != null)
                {
                    SelectedTabControlIndex = 1;
                    DataGridCollection = MC.IssueViewList.Where(x => x.project_id == AppSessionState.TransValueType.ToString()).ToList();
                    IssueCollection = CollectionViewSource.GetDefaultView(DataGridCollection);

                    AppSessionState.TransValueType = null;
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

        private void InsertProjectName(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_T001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProjectList.Where(x => x.project_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_T001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_P>().ToList()[0];
                    }

                }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.project_id = POPUPEntityObject.project_id;
                    MasterEntity.project_name = POPUPEntityObject.project_name;

                    FilterCollectionsOnProjectSelection();
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


        private void FilterCollectionsOnProjectSelection()
        {
            if (MasterEntity.project_id != null && MasterEntity.project_id != "")
            {
                // Filtering Collections Based On Project Selection

                //Project Phases
                List<PRO_T001_A_P> SelectedProjectPhases = (from o in MC.PhasesList
                                                            where o.project_id == MasterEntity.project_id
                                                            select o).ToList();

                StrListPhase = SelectedProjectPhases.Select(x => x.phase_id).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_A_P)x).phase_id.ToString());
                TheFilter = (o, prefix) => (((PRO_T001_A_P)o).phase_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_T001_A_P)o).phase_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPhase = new AutoSuggestTextViewModel<dynamic>(SelectedProjectPhases, TheFilter, SuggestedValue, "phase_id", true);
                ASPhase.AutoSuggestVM.IsEmptyValueAllowed = true;


                // Only Project Team and Manager

                List<PRO_T001_B_P> SelectedProjectAssignedTo = (from o in MC.AssignedToList
                                                                where o.project_id == MasterEntity.project_id
                                                                select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASAssignedTo = new AutoSuggestTextViewModel<dynamic>(SelectedProjectAssignedTo, TheFilter, SuggestedValue, "EmpId", true);
                ASAssignedTo.AutoSuggestVM.IsEmptyValueAllowed = true;

                StrListAssginedTo = SelectedProjectAssignedTo.Select(x => x.EmpId).ToList();


                

                //Filter Collection Done By

                List<PRO_T001_B_P> SelectedProjectDoneBy = (from o in MC.WorkDoneByList
                                                            where o.project_id == MasterEntity.project_id
                                                            select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).role_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDoneBy = new AutoSuggestTextViewModel<dynamic>(SelectedProjectDoneBy, TheFilter, SuggestedValue, "done_by", "EmpId", true);
                ASDoneBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDoneBy.AutoSuggestVM.IsFreeTextAllowed = false;

                StrListDoneby = SelectedProjectDoneBy.Select(x => x.EmpId).ToList();

            }
        }


        private void InsertPhase(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_T001_A_P POPUPEntityObject = null;

                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PhasesList.Where(x => x.phase_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_T001_A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_A_P>().ToList()[0];
                    }

                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.phase_id = POPUPEntityObject.phase_id;
                    MasterEntity.phase_name = POPUPEntityObject.phase_name;


                    //Tasks in phase
                    List<PRO_T002_P> SelectedPhaseTask = (from o in MC.TaskList
                                                          where (o.project_id == MasterEntity.project_id) && (o.phase_id == MasterEntity.phase_id)
                                                          select o).ToList();

                    StrListTasks = SelectedPhaseTask.Select(x => x.task_id).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P)x).task_id.ToString());
                    TheFilter = (o, prefix) => (((PRO_T002_P)o).task_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T002_P)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASTask = new AutoSuggestTextViewModel<dynamic>(SelectedPhaseTask, TheFilter, SuggestedValue, "task_id", true);
                    ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;

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

        private void InsertTask(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_T002_P POPUPEntityObject = null;

                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaskList.Where(x => x.task_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_T002_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T002_P>().ToList()[0];
                    }

                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.task_id = POPUPEntityObject.task_id;
                    MasterEntity.title = POPUPEntityObject.title;
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

        private void InsertAssignedTo(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_T001_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AssignedToList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_T001_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_B_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.assign_to = POPUPEntityObject.EmpId;
                    MasterEntity.assignto_name = POPUPEntityObject.EmpLName;
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

        private void InsertReporterName(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ReporterNameList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.reporter_id = POPUPEntityObject.EmpId;
                    MasterEntity.reporter_name = POPUPEntityObject.EmpLName;
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

        private void InsertIssueCategory(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.IssueCategoryList.Where(x => x.cat_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cat_id = POPUPEntityObject.cat_id;
                    MasterEntity.cat_title = POPUPEntityObject.cat_title;
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

        private void InsertDoneByEmp(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            try
            {
                string Request = "";
                PRO_T001_B_P POPUPEntityObject = null;
                dgSelectedIndexAction = dgSelectedIndexAction;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WorkDoneByList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PRO_T001_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ActionLogEntity.Where(X => X.done_by == POPUPEntityObject.EmpId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ActionLogEntity.IndexOf(ActionLogEntity.Where(X => X.done_by == POPUPEntityObject.EmpId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexAction >= 0 && ActionLogEntity.Count > dgSelectedIndexAction) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ActionLogEntity[dgSelectedIndexAction].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ActionLogEntity[dgSelectedIndexAction].done_by = POPUPEntityObject.EmpId;
                            ActionLogEntity[dgSelectedIndexAction].done_by_name = POPUPEntityObject.EmpLName;
                        }
                        else if (ActionLogEntity[dgSelectedIndexAction].done_by != POPUPEntityObject.EmpId)
                        {
                            ActionLogEntity[dgSelectedIndexAction].done_by = POPUPEntityObject.EmpId;
                            ActionLogEntity[dgSelectedIndexAction].done_by_name = POPUPEntityObject.EmpLName;
                        }
                    }
                }

                #region Clear Empty Row

                PRO_T003_A newObj = new PRO_T003_A();
                for (int i = ActionLogEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ActionLogEntity[i].ComparePropertiesTo(newObj);
                    if (ActionLogEntity[i].ComparePropertiesTo(newObj) == true && ActionLogEntity.Count > 1)
                    {
                        ActionLogEntity.RemoveAt(i);
                        if (ActionLogEntity.Count == 0)
                        {
                            ActionLogEntity.Add(newObj);
                        }
                    }
                }
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

        private void DeleteDataGridRow_ActionLog(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ActionLogEntity.Count > i && ActionLogEntity[dgSelectedIndexAction].id == 0)
                {
                    ActionLogEntity.RemoveAt(i);
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

        private void LoadDocumentByDocumentNo(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                PRO_T003_View ParameterEntityObject = null;
                MasterEntity = new PRO_T003();


                if (((IEnumerable)ParameterObject).Cast<PRO_T003_View>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_T003_View>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "IS" + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.issue_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                    //Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.issue_id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@";
                    MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T003>(MC_temp, Request, "Issues", "PM", "LoadDocumentByDocumentNumber", 0, MasterEntity.issue_id);

                    MasterEntity = MC_temp.IssueList[0];
                    ActionLogEntity = MC_temp.ActionLogList;

                    ActionLogEntityCount = ActionLogEntity.Count;

                    NewRecord = false;
                    SelectedTabControlIndex = 0;

                    var msg = new NotificationMessage("PRO_T003_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);

                    FilterCollectionsOnProjectSelection();

                    AttachmentCollection = MC_temp.AttachmentData;

                    if (MC_temp.AttachmentData != null)
                    {
                        AttachmentCollection = MC_temp.AttachmentData;
                    }
                    else
                    {
                        MC_temp.AttachmentData = new List<COM_T003>();
                    }
                    MasterEntity.ts_code = ts_code_vm;
                }
                SetPopupSuggestionDataAfterLoad();
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
            //Project List
            ASProject.AutoSuggestVM.Suggestion = MC.ProjectList.Find(x => x.project_id == MasterEntity.project_id);

            //Phases In Selected Project
            List<PRO_T001_A_P> SelectedProjectPhases = (from o in MC.PhasesList
                                                        where o.project_id == MasterEntity.project_id
                                                        select o).ToList();
            ASPhase.AutoSuggestVM.Suggestion = SelectedProjectPhases.Find(x => x.phase_id == MasterEntity.phase_id);

            //Team Members In Selected Project
            List<PRO_T001_B_P> SelectedProjectAssignedTo = (from o in MC.AssignedToList
                                                            where o.project_id == MasterEntity.project_id
                                                            select o).ToList();
            ASAssignedTo.AutoSuggestVM.Suggestion = SelectedProjectAssignedTo.Find(x => x.EmpId == MasterEntity.assign_to);

            //Tasks In Selected Project
            List<PRO_T002_P> SelectedPhaseTask = (from o in MC.TaskList
                                                  where (o.project_id == MasterEntity.project_id) && (o.phase_id == MasterEntity.phase_id)
                                                  select o).ToList();

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P)x).task_id.ToString());
            TheFilter = (o, prefix) => (((PRO_T002_P)o).task_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T002_P)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
            ASTask = new AutoSuggestTextViewModel<dynamic>(SelectedPhaseTask, TheFilter, SuggestedValue, "task_id", true);
            ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;
            ASTask.AutoSuggestVM.Suggestion = SelectedPhaseTask.Find(x => x.task_id == MasterEntity.task_id);
          
        }

        private bool ValidateControls()
        {
            if (MasterEntity.project_id == null || MasterEntity.project_id == "" ||
                MasterEntity.doc_date == null ||            
              //MasterEntity.assign_to == null || MasterEntity.assign_to == "" ||
                MasterEntity.issue_name == null || MasterEntity.title == "" ||
                MasterEntity.facing_from_date  == null ||
                MasterEntity.reporting_date  == null ||
                MasterEntity.reporter_name  == null || MasterEntity.reporter_name == "" ||
                MasterEntity.description  == null || MasterEntity.description == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation: Compulsory Fields";
                showMessageService.Text = String.Format("Fields Issue Title, Project , Document Date, Issue Description ,facing from Date, Reporting Date, Reporter Name are Compulsory ", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (ActionLogEntity.Count > 0)
            {
                foreach (var o in ActionLogEntity)
                {
                    if (o.action_summary == null || o.action_summary == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Action Summary";
                        showMessageService.Text = String.Format(" Action Summary cannot be blank At Index {0}", ActionLogEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }                

                     if (o.hours_spent == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Hours Spent";
                        showMessageService.Text = String.Format(" Hours Spent cannot be blank At Index {0}", ActionLogEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                     if (o.end_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Action Date";
                        showMessageService.Text = String.Format(" Action Date cannot be blank At Index {0}", ActionLogEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                     if (o.done_by == null || o.done_by == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Done By";
                        showMessageService.Text = String.Format(" Done By cannot be blank At Index {0}", ActionLogEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                     if (o.t_status == null || o.t_status == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Status";
                        showMessageService.Text = String.Format(" Status cannot be blank At Index {0}", ActionLogEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

            }
            return true;
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_PRO_T003_A != null)
                {
                    MC.ActionLogList = (ObservableCollection<PRO_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T003_A, MC.ActionLogList);
                    ActionLogEntity.Clear();
                    ActionLogEntity = MC.ActionLogList;
                }
                else
                {
                    MC.ActionLogList = new ObservableCollection<PRO_T003_A>();
                }

                if (MasterEntity.XmlDataDocument_View != null)
                {
                    MC.IssueViewList = (List<PRO_T003_View>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_View, MC.IssueViewList);
                    DataGridCollection.Add(MC.IssueViewList[0]);
                    _IssueCollection.Refresh();
                   
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

        void ModelUpdated_ActionSummary(object sender, EventArgs e)
        {
            try
            {

                if (sender.ToString() == "action_summary" && dgSelectedIndexAction != -1 && dgSelectedIndexAction < ActionLogEntity.Count)
                {
                    if (ActionLogEntity.Count > 0)
                    {
                        if (ActionLogEntity[dgSelectedIndexAction].end_date == Convert.ToDateTime("01 / 01 / 0001 00:00:00"))
                        {
                            ActionLogEntity[dgSelectedIndexAction].end_date = DateTime.UtcNow;
                        }

                        ActionLogEntity[dgSelectedIndexAction].active = true;
                        ActionLogEntity[dgSelectedIndexAction].add_by = AppSessionState.UserID;
                        ActionLogEntity[dgSelectedIndexAction].editby = AppSessionState.UserID;
                        ActionLogEntity[dgSelectedIndexAction].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                    }
                                      
                }
                if (sender.ToString() == "end_date" && dgSelectedIndexAction != -1 && dgSelectedIndexAction < ActionLogEntity.Count)
                {
                    MasterEntity.last_action_date = Convert.ToDateTime((from o in ActionLogEntity
                                                                        orderby o.end_date descending
                                                                        select o.end_date).First().ToLongDateString());

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

        private void ViewIssueTimesheet()
        {
            if (ActionLogEntityCount > 0)
            {
                try
                {
                    SYS_AUTH userAuth = new SYS_AUTH();

                    string TransactionCode = MC.Doc_typeList.Where(x => x.doc_type == "TS").Select(x => x.TranCode).FirstOrDefault();

                    if (MasterEntity != null && MasterEntity.issue_id != null && MasterEntity.issue_id != "")
                    {
                        var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == TransactionCode).FirstOrDefault();
                        userAuth = docdetails;
                        //AppSessionState.UserAuthSingle = userAuth;
                        AppSessionState.ViewTitle = userAuth.ts_code;
                        AppSessionState.TransValueType = MasterEntity.issue_id;
                        //AppSessionState.TransId = userAuth.menu_code.ToString();

                        if (userAuth.class_file != null && userAuth.class_file != "")
                        {
                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType(userAuth.class_file);
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type);
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("There is no Timesheet for this Issue \n Please Insert data in Action Summary.");
                showMessageService.ShowMessage();
            }

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNo(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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

        #endregion

        #region Abstract Command Actions                                                                                                                                                                                                                        
        protected override void OnSaveAction(InquiryActionResult<PRO_T003> result)
        {
            try
            {
                ObjectSerializationService objser = new ObjectSerializationService();


                if (ValidateControls() == true)
                {
                    MasterEntity.XmlDataDocument_PRO_T003_A = objser.ObjectToXML(ActionLogEntity);
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PRO_T003>(MasterEntity, "Issues", "PM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PRO_T003>(MasterEntity, "Issues", "PM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
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

        protected override void OnCreateAction(InquiryActionResult<PRO_T003> result)
        {
            try
            {
                NewRecord = true;
                MasterEntity = new PRO_T003();
                ActionLogEntity = new ObservableCollection<PRO_T003_A>();
                DefaultValues();
                IssueCollection.Refresh();
                MasterEntity.ValidateAsync().Wait();
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
        protected override void OnRemoveAction(InquiryActionResult<PRO_T003> result)
        {
           
        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_T003> result)
        {
            //MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_T003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_T003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_T003> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_T003> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<PRO_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_T003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.issue_id))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.issue_id.Replace("/", "--"), DocumentList = MC_temp.AttachmentData, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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

        #region Filter Issues
        public bool FilterIssues(object obj)
        {
            var data = obj as PRO_T003_View;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringIssues))
                {
                    return (data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||                         
                            data.phase_name != null && data.phase_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.task_name  != null && data.task_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.issue_id  != null && data.issue_id.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.issue_name  != null && data.issue_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.assignto_name  != null && data.assignto_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterStringIssues.ToLower()) ||
                            data.reporter_name  != null && data.reporter_name.ToString().ToLower().Contains(_filterStringIssues.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringIssues;
        public string filterStringIssues
        {
            get { return _filterStringIssues; }
            set
            {
                _filterStringIssues = value;
                RaisePropertyChanged("filterStringIssues");
                FilterStringIssues();
            }
        }
        private void FilterStringIssues()
        {
            if (_IssueCollection  != null)
            {
                _IssueCollection.Refresh();
            }
        }

        
        #endregion
    }
}
