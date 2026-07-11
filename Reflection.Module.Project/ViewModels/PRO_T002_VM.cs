using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
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
    public class PRO_T002_VM : WorkspaceViewModel<PRO_T002>
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

        private AutoSuggestTextViewModel<dynamic> _ASReviewer { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReviewer
        {
            get { return _ASReviewer; }
            set
            {
                if (_ASReviewer != value)
                {
                    _ASReviewer = value; RaisePropertyChanged("ASReviewer");
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

        private AutoSuggestTextViewModel<dynamic> _ASWorkSummary { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWorkSummary
        {
            get { return _ASWorkSummary; }
            set
            {
                if (_ASWorkSummary != value)
                {
                    _ASWorkSummary = value; RaisePropertyChanged("_ASWorkSummary");
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

                    if (SourceName == "EmpId")
                    { ASDefault = ASDoneBy; }
                    else if (SourceName == "work_summary")
                    { ASDefault = ASWorkSummary; }

                }
            }

        }
        private AutoSuggestTextViewModel<dynamic> _ASTask { get; set; }
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
        #endregion

        #region Variable Declaration

        WebServiceRepository<MultipleContext_PRO_T002> repository_MC = new WebServiceRepository<MultipleContext_PRO_T002>();
        WebServiceRepository<PRO_T002> repository = new WebServiceRepository<PRO_T002>();
        MultipleContext_PRO_T002 _MC = new MultipleContext_PRO_T002();
        MultipleContext_PRO_T002 MC_temp = new MultipleContext_PRO_T002();

        bool NewRecord = true;
        int WorkSummaryCount;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public MultipleContext_PRO_T002 MC
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

        private PRO_T002 _MasterEntity;
        public PRO_T002 MasterEntity
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

        private int _dgSelectedIndexWork;
        public int dgselectedIndexWork
        {
            get { return _dgSelectedIndexWork; }
            set
            {
                if (_dgSelectedIndexWork != null)
                {
                    _dgSelectedIndexWork = value;
                    RaisePropertyChanged("dgselectedIndexWork");

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

        private ObservableCollection<PRO_T002_A> _WorkSummaryEntity;
        public ObservableCollection<PRO_T002_A> WorkSummaryEntity
        {
            get { return _WorkSummaryEntity; }
            set
            {
                if (_WorkSummaryEntity != value)
                {
                    _WorkSummaryEntity = value;
                    RaisePropertyChanged("WorkSummaryEntity");
                }
            }
         }

        private List<PRO_T002_View> _DataGridCollection = new List<PRO_T002_View>();
        public List<PRO_T002_View> DataGridCollection
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

        private ICollectionView _TaskCollection;
        public ICollectionView TaskCollection
        {
            get { return _TaskCollection; }
            set
            {
                _TaskCollection = value;
                RaisePropertyChanged("TaskCollection");
            }

        }

        private ICollectionView _WorkSummaryCollection;
        public ICollectionView WorkSummaryCollection
        {
            get { return _WorkSummaryCollection; }
            set { _WorkSummaryCollection = value; RaisePropertyChanged("WorkSummaryCollection"); }
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
                    RaisePropertyChanged("StrListPrjName");
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

        private List<string> _strListReviewer;
        public List<string> StrListReviewer
        {
            get { return _strListReviewer; }
            set
            {
                if (_strListReviewer != value)
                {
                    _strListReviewer = value;
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

        private List<string> _strListWorkSummary;
        public List<string> StrListWorkSummary
        {
            get { return _strListWorkSummary; }
            set
            {
                if (_strListWorkSummary != value)
                {
                    _strListWorkSummary = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> cmdProject { get; private set; }
        public RelayCommand<object> cmdPhase { get; private set; }
        public RelayCommand<object> cmdAssignedTo { get; private set; }
        public RelayCommand<object> cmdReviewer { get; private set; }

        public GalaSoft.MvvmLight.Command.RelayCommand cmdViewTaskTimesheet { get; private set; }

        public RelayCommand<object> cmdCategory { get; private set; }
        public RelayCommand<object> cmdWorkSummary { get; private set; }
        public RelayCommand<object> cmdDoneByEmp { get; private set; }

        public RelayCommand<object> cmdDeleteDataGridRowWorkSummary { get; private set; }
        
        public RelayCommand<object> cmdLoadDocumentByDocumentNo { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdTask { get; private set; }

        #endregion

        #region Constructor
        public PRO_T002_VM(string ts_code) : base()
        {
            MasterEntity = new PRO_T002();
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_PRO_T002();
            WorkSummaryEntity = new ObservableCollection<PRO_T002_A>();

            DefaultValues();

            MasterEntity.ValidateAsync().Wait();

            PRO_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_WorkSummary);

            

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
        public PRO_T002_VM(string ts_code,string doc_no) : base()
        {
            MasterEntity = new PRO_T002();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_PRO_T002();
            WorkSummaryEntity = new ObservableCollection<PRO_T002_A>();

            DefaultValues();

            MasterEntity.ValidateAsync().Wait();

            PRO_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_WorkSummary);



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
                MasterEntity.doc_cat = "TK";
                MasterEntity.doc_type = "TK";
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.comp_code = AppSessionState.comp_code;
                //MasterEntity.user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = "001";
                MasterEntity.doc_date = DateTime.UtcNow;
                MasterEntity.start_date = null;
                MasterEntity.dead_date = null;
                MasterEntity.ts_code=ts_code_vm;
                MasterEntity.client = AppSessionState.client;
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

                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "TK" + "!@" + "TK" + "!@" + (MasterEntity.task_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                //string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T002>(MC, Request, "Tasks", "PM", "LoadAll", 0, "");

                #region Command Initialisation

                cmdProject = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectName(items); });
                cmdPhase = new RelayCommand<object>(items => { if (items == null) { return; } InsertPhase(items); });
                cmdAssignedTo = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignedTo(items); });
                cmdReviewer = new RelayCommand<object>(items => { if (items == null) { return; } InsertReveiwer(items); });

                cmdViewTaskTimesheet = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewTaskTimesheet(); });

                //cmdCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });

                cmdDoneByEmp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDoneByEmp(cmdPara, false, true, true); });
                cmdWorkSummary = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWorkSummary(cmdPara, true, true, true); });

                cmdTask = new RelayCommand<object>(items => { if (items == null) { return; } InsertTask(items); });
                cmdDeleteDataGridRowWorkSummary = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_WorkSummary(cmdPara); });// confirm assignment

                cmdLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNo(cmdPara, "FlipGridReference"); }); // confirm assignment   
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion
                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_P)x).project_id);
                TheFilter = (o, prefix) => (((PRO_T001_P)o).project_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_P)o).project_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.ProjectList, TheFilter, SuggestedValue, "project_id", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;                

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.WorkDoneByList, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_A_P)x).work_summary.ToString());
                TheFilter = (o, prefix) => (((PRO_T002_A_P)o).work_summary ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWorkSummary = new AutoSuggestTextViewModel<dynamic>(MC.WorkSummaryForPopUPList, TheFilter, SuggestedValue, "work_summary", "work_summary", true);
                ASWorkSummary.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASWorkSummary.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M006)x).task_code);
                TheFilter = (o, prefix) => (((PRO_M006)o).task_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_M006)o).task_nm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTask = new AutoSuggestTextViewModel<dynamic>(MC.TaskMasterList, TheFilter, SuggestedValue, "task_code", true);
                ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;

                StrListWorkSummary = WorkSummaryEntity.Select(x => x.work_summary).ToList();

                #endregion

                StrListPrjName = MC.ProjectList.Select(x => x.project_id).ToList();
                                             
                DataGridCollection = MC.TaskViewList;
                TaskCollection = CollectionViewSource.GetDefaultView(DataGridCollection);
                TaskCollection.Filter = new Predicate<object>(FilterTask);

                WorkSummaryCollection = CollectionViewSource.GetDefaultView(MC.WorkSummaryForPopUPList.ToList());
                WorkSummaryCollection.Filter = new Predicate<object>(FilterWorkSummary);
                StrListWorkSummary = MC.WorkSummaryForPopUPList.Select(x => x.work_summary).ToList();

                if (AppSessionState.TransValueType != null)
                {
                    SelectedTabControlIndex = 1;
                    DataGridCollection = MC.TaskViewList.Where(x => x.project_id == AppSessionState.TransValueType.ToString()).ToList();
                    TaskCollection = CollectionViewSource.GetDefaultView(DataGridCollection);

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

                List<PRO_T001_B_P> SelectedProjectReviewer = (from o in MC.ReviewerList
                                                              where o.project_id == MasterEntity.project_id
                                                              select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReviewer = new AutoSuggestTextViewModel<dynamic>(SelectedProjectReviewer, TheFilter, SuggestedValue, "EmpId", true);
                ASReviewer.AutoSuggestVM.IsEmptyValueAllowed = true;

                StrListReviewer = SelectedProjectReviewer.Select(x => x.EmpId).ToList();


                List<PRO_T001_B_P> SelectedProjectDoneBy = (from o in MC.AssignedToList
                                                            where o.project_id == MasterEntity.project_id
                                                            select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B_P)x).EmpId);
                TheFilter = (o, prefix) => (((PRO_T001_B_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDoneBy = new AutoSuggestTextViewModel<dynamic>(SelectedProjectDoneBy, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                ASDoneBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDoneBy.AutoSuggestVM.IsFreeTextAllowed = false;

                StrListDoneby = SelectedProjectDoneBy.Select(x => x.EmpId).ToList();
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

        private void InsertTask(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_M006 POPUPEntityObject = null;

                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaskMasterList.Where(x => x.task_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_M006>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M006>().ToList()[0];
                    }

                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.task_code = POPUPEntityObject.task_code;                    
                    MasterEntity.title = POPUPEntityObject.task_nm;
                    MasterEntity.t_description = POPUPEntityObject.task_desc;
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
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
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
        private void InsertReveiwer(object InputValue)
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
                        { POPUPEntityObject = MC.ReviewerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.reviewer_id = POPUPEntityObject.EmpId;
                    MasterEntity.reviewer_name = POPUPEntityObject.EmpLName;
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

        private void ViewTaskTimesheet()
        {
            if (WorkSummaryCount > 0)
            {
                try
                {
                    SYS_AUTH userAuth = new SYS_AUTH();

                    string TransactionCode = MC.Doc_typeList.Where(x => x.doc_type == "TS").Select(x => x.TranCode).FirstOrDefault();

                    if (MasterEntity != null && MasterEntity.task_id != null && MasterEntity.task_id != "")
                    {
                        var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == TransactionCode).FirstOrDefault();
                        userAuth = docdetails;
                        //AppSessionState.UserAuthSingle = userAuth;
                        AppSessionState.ViewTitle = userAuth.ts_name;
                        AppSessionState.TransValueType = MasterEntity.task_id;
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
                showMessageService.Text = String.Format("There is no Timesheet for this Task \n Please Insert data in Work Summary.");
                showMessageService.ShowMessage();
            }
        }


        void ModelUpdated_WorkSummary(object sender, EventArgs e)
        {
            try
            {

                if (sender.ToString() == "work_summary" && dgselectedIndexWork != -1 && dgselectedIndexWork < WorkSummaryEntity.Count)
                {
                    if (WorkSummaryEntity.Count > 0)
                    {
                        if (WorkSummaryEntity[dgselectedIndexWork].end_date ==  Convert.ToDateTime("01 / 01 / 0001 00:00:00"))
                        {
                            WorkSummaryEntity[dgselectedIndexWork].end_date = DateTime.UtcNow;
                        }
                        
                        WorkSummaryEntity[dgselectedIndexWork].active = true;
                        WorkSummaryEntity[dgselectedIndexWork].add_by = AppSessionState.UserID;
                        WorkSummaryEntity[dgselectedIndexWork].editby = AppSessionState.UserID;
                        WorkSummaryEntity[dgselectedIndexWork].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                    }                       
                }

                if (sender.ToString() == "hours_spent" && dgselectedIndexWork != -1 && dgselectedIndexWork < WorkSummaryEntity.Count)
                {
                    MasterEntity.hours_spent = WorkSummaryEntity.Where(x => x.active == true).Sum(X => X.hours_spent);

                    MasterEntity.remaining_hours = MasterEntity.plan_hours - MasterEntity.hours_spent;

                    if (MasterEntity.remaining_hours < 0)
                    {
                        MasterEntity.delay_hours = -MasterEntity.remaining_hours;
                        MasterEntity.remaining_hours = 0;
                        MasterEntity.total_hours = MasterEntity.plan_hours + MasterEntity.delay_hours;
                        MasterEntity.progress = Convert.ToDecimal(99.99);
                    }
                    else if (MasterEntity.remaining_hours == 0)
                    {
                        MasterEntity.delay_hours = MasterEntity.remaining_hours;
                        MasterEntity.total_hours = MasterEntity.plan_hours;
                        MasterEntity.progress = Convert.ToDecimal(99.99);
                    }
                    else
                    {
                        if (MasterEntity.plan_hours > 0)
                        {
                            MasterEntity.progress = MasterEntity.hours_spent * 100 / MasterEntity.plan_hours;
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

        private void InsertWorkSummary(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_T002_A_P POPUPEntityObject = null;
                dgselectedIndexWork = dgselectedIndexWork;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WorkSummaryForPopUPList.Where(x => x.work_summary.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T002_A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = WorkSummaryEntity.Where(X => X.work_summary == POPUPEntityObject.work_summary).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = WorkSummaryEntity.IndexOf(WorkSummaryEntity.Where(X => X.work_summary == POPUPEntityObject.work_summary).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && WorkSummaryEntity.Count == dgselectedIndexWork)
                    {
                        WorkSummaryEntity.Add(new PRO_T002_A()
                        {
                            work_summary = POPUPEntityObject.work_summary,
                            t_status = "001",
                            end_date = DateTime.Now,
                            active = true,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2
                        });
                    }
                    else if (dgselectedIndexWork >= 0 && WorkSummaryEntity.Count > dgselectedIndexWork) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (WorkSummaryEntity[dgselectedIndexWork].work_summary == "0" && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            WorkSummaryEntity[dgselectedIndexWork].work_summary  = POPUPEntityObject.work_summary;                    
                            WorkSummaryEntity[dgselectedIndexWork].active = true;
                            WorkSummaryEntity[dgselectedIndexWork].end_date = DateTime.Now;
                            WorkSummaryEntity[dgselectedIndexWork].add_by = AppSessionState.UserID;
                            WorkSummaryEntity[dgselectedIndexWork].editby = AppSessionState.UserID;
                            WorkSummaryEntity[dgselectedIndexWork].location_Id = AppSessionState.location_Id;
                            WorkSummaryEntity[dgselectedIndexWork].comp_code = AppSessionState.comp_code;
                            WorkSummaryEntity[dgselectedIndexWork].client = AppSessionState.client;
                            WorkSummaryEntity[dgselectedIndexWork].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                        }
                        else if (WorkSummaryEntity[dgselectedIndexWork].work_summary != POPUPEntityObject.work_summary)
                        {
                            WorkSummaryEntity[dgselectedIndexWork].work_summary = "";
                        }
                    }

                    if (WorkSummaryEntity != null)
                    {                     
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_A_P)x).work_summary.ToString());
                        TheFilter = (o, prefix) => (((PRO_T002_A_P)o).work_summary ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASWorkSummary = new AutoSuggestTextViewModel<dynamic>(MC.WorkSummaryForPopUPList, TheFilter, SuggestedValue, "work_summary", "work_summary", true);
                        ASWorkSummary.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASWorkSummary.AutoSuggestVM.IsFreeTextAllowed = true;

                        StrListWorkSummary = WorkSummaryEntity.Select(x => x.work_summary).ToList();

                    }
                }

                #region Clear Empty Row
                PRO_T002_A newObj = new PRO_T002_A();
                for (int i = WorkSummaryEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = WorkSummaryEntity[i].ComparePropertiesTo(newObj);
                    if (WorkSummaryEntity[i].ComparePropertiesTo(newObj) == true && WorkSummaryEntity.Count > 1)
                    {
                        WorkSummaryEntity.RemoveAt(i);
                        if (WorkSummaryEntity.Count == 0)
                        {
                            WorkSummaryEntity.Add(newObj);
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
        private void InsertDoneByEmp(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            try
            {
                string Request = "";
                PRO_T001_B_P POPUPEntityObject = null;
                dgselectedIndexWork = dgselectedIndexWork;

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
                    var InputValueIfExists = WorkSummaryEntity.Where(X => X.EmpId == POPUPEntityObject.EmpId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = WorkSummaryEntity.IndexOf(WorkSummaryEntity.Where(X => X.EmpId == POPUPEntityObject.EmpId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgselectedIndexWork >= 0 && WorkSummaryEntity.Count > dgselectedIndexWork) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (WorkSummaryEntity[dgselectedIndexWork].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            WorkSummaryEntity[dgselectedIndexWork].EmpId = POPUPEntityObject.EmpId;
                            WorkSummaryEntity[dgselectedIndexWork].done_by_name = POPUPEntityObject.EmpLName;
                        }
                        else if (WorkSummaryEntity[dgselectedIndexWork].EmpId != POPUPEntityObject.EmpId)
                        {
                            WorkSummaryEntity[dgselectedIndexWork].EmpId = POPUPEntityObject.EmpId;
                            WorkSummaryEntity[dgselectedIndexWork].done_by_name = POPUPEntityObject.EmpLName;
                        }
                    }
                }
                #region Clear Empty Row
                PRO_T002_A newObj = new PRO_T002_A();
                for (int i = WorkSummaryEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = WorkSummaryEntity[i].ComparePropertiesTo(newObj);
                    if (WorkSummaryEntity[i].ComparePropertiesTo(newObj) == true && WorkSummaryEntity.Count > 1)
                    {
                        WorkSummaryEntity.RemoveAt(i);
                        if (WorkSummaryEntity.Count == 0)
                        {
                            WorkSummaryEntity.Add(newObj);
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
        private void DeleteDataGridRow_WorkSummary(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (WorkSummaryEntity.Count > i && WorkSummaryEntity[dgselectedIndexWork].id == 0)
                {
                    WorkSummaryEntity.RemoveAt(i);
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
                PRO_T002_View ParameterEntityObject = null;
                MasterEntity = new PRO_T002();

                
                if (((IEnumerable)ParameterObject).Cast<PRO_T002_View>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_T002_View>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "TK" + "!@" + "TK" + "!@" + ParameterEntityObject.task_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                   // Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.task_id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@";
                    MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T002>(MC_temp, Request, "Tasks", "PM", "LoadDocumentByDocumentNumber", 0, MasterEntity.task_id);

                    MasterEntity = MC_temp.TaskList[0];
                    WorkSummaryEntity = MC_temp.WorkSummaryList;

                    WorkSummaryCount = WorkSummaryEntity.Count();
                    NewRecord = false;
                    SelectedTabControlIndex = 0;

                    var msg = new NotificationMessage("PRO_T002_VM");
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

                }
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
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

        private void SetPopupSuggestionDataAfterLoad()
        {

            ASProject.AutoSuggestVM.Suggestion = MC.ProjectList.Find(x => x.project_id == MasterEntity.project_id);


            List<PRO_T001_A_P> SelectedProjectPhases = (from o in MC.PhasesList
                                                        where o.project_id == MasterEntity.project_id
                                                        select o).ToList();
             ASPhase.AutoSuggestVM.Suggestion = SelectedProjectPhases.Find(x => x.phase_id == MasterEntity.phase_id);


            List<PRO_T001_B_P> SelectedProjectAssignedTo = (from o in MC.AssignedToList
                                                            where o.project_id == MasterEntity.project_id
                                                            select o).ToList();
            ASAssignedTo.AutoSuggestVM.Suggestion = SelectedProjectAssignedTo.Find(x => x.EmpId == MasterEntity.EmpId);


            List<PRO_T001_B_P> SelectedProjectReviewer = (from o in MC.ReviewerList
                                                          where o.project_id == MasterEntity.project_id
                                                          select o).ToList();
            ASReviewer.AutoSuggestVM.Suggestion = SelectedProjectReviewer.Find(x => x.EmpId == MasterEntity.reviewer_id);
        }

        private bool ValidateControls()
        {
            try
            {
                if (MasterEntity.project_id == null || MasterEntity.project_id == "" ||
                    MasterEntity.doc_date == null ||
                    MasterEntity.phase_id == null || MasterEntity.phase_id == "" ||
                    MasterEntity.EmpId == null || MasterEntity.EmpId == "" ||
                    MasterEntity.title == null || MasterEntity.title == "" ||
                    MasterEntity.sequence == null || MasterEntity.sequence == 0 ||
                    MasterEntity.plan_hours == null || MasterEntity.plan_hours == 0 ||
                    MasterEntity.t_description == null || MasterEntity.t_description == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation:";
                    showMessageService.Text = String.Format("Fields Task Title, Project , Phase, Document Date, Assigned To, Planned Hours, Sequence No, Task Description are Compulsory \n Planned Hours and Sequence No Should be Greater Than 0", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                if (WorkSummaryEntity.Count > 0)
                {
                    if (MasterEntity.t_status == null || MasterEntity.t_status == "" || MasterEntity.t_status == "001")
                    {
                        MasterEntity.t_status = "018";
                    }
                }

                foreach (var o in WorkSummaryEntity)
                {
                    if (o.work_summary == null || o.work_summary == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Action Summary";
                        showMessageService.Text = String.Format(" Action Summary cannot be blank At Index {0}", WorkSummaryEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.hours_spent == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Hours Spent";
                        showMessageService.Text = String.Format(" Hours Spent cannot be blank At Index {0}", WorkSummaryEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.end_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Action Date";
                        showMessageService.Text = String.Format(" Action Date cannot be blank At Index {0}", WorkSummaryEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.EmpId == null || o.EmpId == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Done By";
                        showMessageService.Text = String.Format(" Done By cannot be blank At Index {0}", WorkSummaryEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.t_status == null || o.t_status == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Status";
                        showMessageService.Text = String.Format(" Status cannot be blank At Index {0}", WorkSummaryEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_PRO_T002_A != null)
                {
                    MC.WorkSummaryList = (ObservableCollection<PRO_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T002_A, MC.WorkSummaryList);
                    WorkSummaryEntity.Clear();
                    WorkSummaryEntity = MC.WorkSummaryList;
                }
                else
                {
                    MC.WorkSummaryList = new ObservableCollection<PRO_T002_A>();
                }

                if (MasterEntity.XmlDataDocument_View != null)
                {
                    MC.TaskViewList = (List<PRO_T002_View>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_View, MC.TaskViewList);
                    DataGridCollection.Add(MC.TaskViewList[0]);
                    _TaskCollection.Refresh();
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

        //private void InsertCategory(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        PRO_M001_P POPUPEntityObject = null;
        //        #region Command Parameter Read Section

        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = MC.CategoryList.Where(x => x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            if (((IEnumerable)InputValue).Cast<PRO_M001_P>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M001_P>().ToList()[0];
        //            }

        //        }


        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.cat_id = POPUPEntityObject.id;
        //            MasterEntity.Categorynm = POPUPEntityObject.name;

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

        #region Abstract Command Actions                                                                                                                                                                                                                        
        protected override void OnSaveAction(InquiryActionResult<PRO_T002> result)
        {

            ObjectSerializationService objser = new ObjectSerializationService();
            

            if (ValidateControls() == true)
            {
                MasterEntity.XmlDataDocument_PRO_T002_A = objser.ObjectToXML(WorkSummaryEntity);
                this.MasterEntity.EndEdit();

                if (NewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<PRO_T002>(MasterEntity, "Tasks", "PM");                   
                }
                else if (NewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<PRO_T002>(MasterEntity, "Tasks", "PM");
                }

                SetBusinessEntitiesAfterLoad("Save", "");
                NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
            }

        }
        protected override void OnCreateAction(InquiryActionResult<PRO_T002> result)
        {

            NewRecord = true;


            MasterEntity = new PRO_T002();
            WorkSummaryEntity = new ObservableCollection<PRO_T002_A>();
            DefaultValues();
            TaskCollection.Refresh();
            MasterEntity.ValidateAsync().Wait();


        }
        protected override void OnRemoveAction(InquiryActionResult<PRO_T002> result)
        {
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text = String.Format("This record will delete forever'{0}'", this.Title);
            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{

            //    this.MasterEntity.EndEdit();
            //    string response = repository.Delete(MasterEntity.task_id, "Tasks", "PM");
            //    selectedList.Remove(MasterEntity);

            //    MasterEntity = new PRO_T002();
            //    dgWorkData = new ObservableCollection<PRO_T002_A>();

            //    TaskCollection.Refresh();

            //}

        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_T002> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.task_id))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.task_id.Replace("/", "--"), DocumentList = MC_temp.AttachmentData, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters    

        public bool FilterTask(object obj)
        {
            var data = obj as PRO_T002_View;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringtask))
                {
                    return (
                             data.task_id != null && data.task_id.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.title != null && data.title.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.project_id != null && data.project_id.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.phase_name != null && data.phase_name.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.assignto_name != null && data.assignto_name.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.reviewer_name != null && data.reviewer_name.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.dependancy != null && data.dependancy.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.dependancy_name != null && data.dependancy_name.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.repeat_id != null && data.repeat_id.ToString().ToLower().Contains(_filterStringtask.ToLower()) ||
                             data.repeat_name != null && data.repeat_name.ToString().ToLower().Contains(_filterStringtask.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringtask;
        public string filterStringtask
        {
            get { return _filterStringtask; }
            set
            {
                _filterStringtask = value;
                RaisePropertyChanged("filterStringtask");
                FilterCollectionTask();
            }
        }

        private void FilterCollectionTask()
        {
            if (_TaskCollection != null)
            {
                _TaskCollection.Refresh();
            }
        }


        #region filter Work Summary
        public bool FilterWorkSummary(object obj)
        {
            var data = obj as PRO_T002_A_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWorkSummary))
                {
                    return (data.work_summary != null && data.work_summary.ToString().ToLower().Contains(_filterStringWorkSummary.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringWorkSummary;
        public string FilterStringWorkSummary
        {
            get { return _filterStringWorkSummary; }
            set
            {
                _filterStringWorkSummary = value;
                RaisePropertyChanged("FilterStringWorkSummary");
                FilterWorkSummary();
            }
        }
        private void FilterWorkSummary()
        {
            if (_WorkSummaryCollection != null)
            {
                _WorkSummaryCollection.Refresh();
            }
        }

        
        #endregion

        #endregion

    }
}