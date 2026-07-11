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
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;

namespace Reflection.Module.Project.ViewModels
{
    public class PRO_T001_VM : WorkspaceViewModel<PRO_T001>
    {
        int mn; // variable to store selected index value temporarily 
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

        private AutoSuggestTextViewModel<dynamic> _ASDefault2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault2
        {
            get { return _ASDefault2; }
            set
            {
                if (_ASDefault2 != value)
                {
                    _ASDefault2 = value; RaisePropertyChanged("ASDefault2");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault3
        {
            get { return _ASDefault3; }
            set
            {
                if (_ASDefault3 != value)
                {
                    _ASDefault3 = value; RaisePropertyChanged("ASDefault3");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault4
        {
            get { return _ASDefault4; }
            set
            {
                if (_ASDefault4 != value)
                {
                    _ASDefault4 = value; RaisePropertyChanged("ASDefault4");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault5 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault5
        {
            get { return _ASDefault5; }
            set
            {
                if (_ASDefault5 != value)
                {
                    _ASDefault5 = value; RaisePropertyChanged("ASDefault5");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault6 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault6
        {
            get { return _ASDefault6; }
            set
            {
                if (_ASDefault6 != value)
                {
                    _ASDefault6 = value; RaisePropertyChanged("ASDefault6");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCustomer { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCustomer
        {
            get { return _ASCustomer; }
            set
            {
                if (_ASCustomer != value)
                {
                    _ASCustomer = value; RaisePropertyChanged("ASCustomer");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASProjectManager { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProjectManager
        {
            get { return _ASProjectManager; }
            set
            {
                if (_ASProjectManager != value)
                {
                    _ASProjectManager = value; RaisePropertyChanged("ASProjectManager");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRefDocNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocNo
        {
            get { return _ASRefDocNo; }
            set
            {
                if (_ASRefDocNo != value)
                {
                    _ASRefDocNo = value; RaisePropertyChanged("ASRefDocNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRefDocNoExport { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocNoExport
        {
            get { return _ASRefDocNoExport; }
            set
            {
                if (_ASRefDocNoExport != value)
                {
                    _ASRefDocNoExport = value; RaisePropertyChanged("ASRefDocNoExport");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItems { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItems
        {
            get { return _ASItems; }
            set
            {
                if (_ASItems != value)
                {
                    _ASItems = value; RaisePropertyChanged("ASItems");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEmployees { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployees
        {
            get { return _ASEmployees; }
            set
            {
                if (_ASEmployees != value)
                {
                    _ASEmployees = value; RaisePropertyChanged("ASEmployees");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRole { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRole
        {
            get { return _ASRole; }
            set
            {
                if (_ASRole != value)
                {
                    _ASRole = value; RaisePropertyChanged("ASRole");
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


        private AutoSuggestTextViewModel<dynamic> _ASCheckList { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCheckList
        {
            get { return _ASCheckList; }
            set
            {
                if (_ASCheckList != value)
                {
                    _ASCheckList = value; RaisePropertyChanged("ASCheckList");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASProCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProCategory
        {
            get { return _ASProCategory; }
            set
            {
                if (_ASProCategory != value)
                {
                    _ASProCategory = value; RaisePropertyChanged("ASProCategory");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProSubCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProSubCategory
        {
            get { return _ASProSubCategory; }
            set
            {
                if (_ASProSubCategory != value)
                {
                    _ASProSubCategory = value; RaisePropertyChanged("ASProSubCategory");
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
        private AutoSuggestTextViewModel<dynamic> _ASMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMake
        {
            get { return _ASMake; }
            set
            {
                if (_ASMake != value)
                {
                    _ASMake = value; RaisePropertyChanged("ASMake");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASModel { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASModel
        {
            get { return _ASModel; }
            set
            {
                if (_ASModel != value)
                {
                    _ASModel = value; RaisePropertyChanged("ASModel");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = ASItems; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }
                    else if (SourceName == "EmpId")
                    { ASDefault = ASEmployees; }
                    else if (SourceName == "RoleCode")
                    { ASDefault = ASRole; }
                    else if (SourceName == "phase_id")
                    { ASDefault = ASPhase; }
                    else if (SourceName == "point_id")
                    { ASDefault = ASCheckList; }
                    else if (SourceName == "EmpId")
                    { ASDefault = ASAssignedTo; }
                    else if (SourceName == "title")
                    { ASDefault = ASTask; }

                }
            }
        }
        #endregion

        #region Variable Declaration.
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        bool NewRecord = true;
        WebServiceRepository<PRO_T001> repository = new WebServiceRepository<PRO_T001>();
        WebServiceRepository<MultipleContext_PRO_T001> repository_MC = new WebServiceRepository<MultipleContext_PRO_T001>();
        MultipleContext_PRO_T001 MCtemp = new MultipleContext_PRO_T001();

        MultipleContext_PRO_T001 _MC = new MultipleContext_PRO_T001();
        public MultipleContext_PRO_T001 MC
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

        MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
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

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }

        private bool _kickoff;
        public bool kickoff
        {
            get { return _kickoff; }

            set
            {
                if (_kickoff != value)
                {
                    _kickoff = value;

                    RaisePropertyChanged("kickoff");
                }
            }
        }

        private PRO_T001 _MasterEntity;
        public PRO_T001 MasterEntity
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

        //For Team DataGrid
        private int _dgSelectedIndexEmp;
        public int dgSelectedIndexEmp
        {
            get
            {
                return _dgSelectedIndexEmp;
            }
            set
            {
                if (_dgSelectedIndexEmp != value)
                {
                    _dgSelectedIndexEmp = value;
                    RaisePropertyChanged("dgSelectedIndexEmp");
                }
            }
        }

        //For Phase Datagrid
        private int _dgSelectedIndexPhase;
        public int dgSelectedIndexPhase
        {
            get { return _dgSelectedIndexPhase; }

            set
            {
                if (_dgSelectedIndexPhase != value)
                {
                    _dgSelectedIndexPhase = value;
                    RaisePropertyChanged("dgSelectedIndexPhase");
                    FilterTaskDataGrid();
                }
            }
        }


        //For Item Datagrid
        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get { return _dgSelectedIndexItem; }

            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                }
            }
        }

        //For Project Final Approval CheckList DataGrid
        private int _dgSelectedIndexApprovalCheckList;
        public int dgSelectedIndexApprovalCheckList
        {
            get { return _dgSelectedIndexApprovalCheckList; }

            set
            {
                if (_dgSelectedIndexApprovalCheckList != value)
                {
                    _dgSelectedIndexApprovalCheckList = value;
                    RaisePropertyChanged("dgSelectedIndexApprovalCheckList");
                }
            }
        }

        //For Project Task Details DataGrid
        private int _dgSelectedIndexTask;
        public int dgSelectedIndexTask
        {
            get { return _dgSelectedIndexTask; }

            set
            {
                if (_dgSelectedIndexTask != value)
                {
                    _dgSelectedIndexTask = value;
                    RaisePropertyChanged("dgSelectedIndexTask");
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

        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }

        private List<PRO_T001_FLIP> _FlipGridData;
        public List<PRO_T001_FLIP> FlipGridData
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

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }

        // Observable Collection for Team Datagrid
        private ObservableCollection<PRO_T001_B> _EmployeeDetailsEntity;
        public ObservableCollection<PRO_T001_B> EmployeeDetailsEntity
        {
            get
            { return _EmployeeDetailsEntity; }
            set
            {
                if (_EmployeeDetailsEntity != value)
                {
                    _EmployeeDetailsEntity = value;

                    RaisePropertyChanged("EmployeeDetailsEntity");
                }
            }
        }


        // Observable Collection for Phase Datagrid
        private ObservableCollection<PRO_T001_A> _PhaseDetailsEntity;
        public ObservableCollection<PRO_T001_A> PhaseDetailsEntity
        {
            get { return _PhaseDetailsEntity; }
            set
            {
                if (_PhaseDetailsEntity != value)
                {
                    _PhaseDetailsEntity = value;

                    RaisePropertyChanged("PhaseDetailsEntity");
                }
            }
        }

        // Observable Collection for Item Datagrid

        private ObservableCollection<PRO_T001_C> _ItemDetailsEntity;
        public ObservableCollection<PRO_T001_C> ItemDetailsEntity
        {
            get { return _ItemDetailsEntity; }
            set
            {
                if (_ItemDetailsEntity != value)
                {
                    _ItemDetailsEntity = value;

                    RaisePropertyChanged("ItemDetailsEntity");
                }
            }
        }

        // Observable Collection for Project Final Approval CheckList

        private ObservableCollection<PRO_T001_D> _FinalApprovalCheckListEntity;
        public ObservableCollection<PRO_T001_D> FinalApprovalCheckListEntity
        {
            get { return _FinalApprovalCheckListEntity; }
            set
            {
                if (_FinalApprovalCheckListEntity != value)
                {
                    _FinalApprovalCheckListEntity = value;

                    RaisePropertyChanged("FinalApprovalCheckListEntity");
                }
            }
        }


        // Observable Collection for Project Task Approval CheckList

        private ObservableCollection<PRO_T002> _TaskDetailsEntity;
        public ObservableCollection<PRO_T002> TaskDetailsEntity
        {
            get { return _TaskDetailsEntity; }
            set
            {

                if (_TaskDetailsEntity != value)
                {
                    _TaskDetailsEntity = value;
                    TaskDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTask);
                    RaisePropertyChanged("TaskDetailsEntity");
                }

            }
        }

        private ObservableCollection<PRO_T002> _TempTaskDetailsEntity;
        public ObservableCollection<PRO_T002> TempTaskDetailsEntity
        {
            get { return _TempTaskDetailsEntity; }
            set
            {

                if (_TempTaskDetailsEntity != value)
                {
                    _TempTaskDetailsEntity = value;
                    RaisePropertyChanged("TempTaskDetailsEntity");
                }

            }
        }


        string store_location;

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

        #endregion

        #region ICollection

        private ICollectionView _TeamCollection;
        public ICollectionView TeamCollection
        {
            get { return _TeamCollection; }
            set { _TeamCollection = value; RaisePropertyChanged("TeamCollection"); }
        }

        private ICollectionView _PhaseCollection;
        public ICollectionView PhaseCollection
        {
            get { return _PhaseCollection; }
            set { _PhaseCollection = value; RaisePropertyChanged("PhaseCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _FinalApprovalCheckListCollection;
        public ICollectionView FinalApprovalCheckListCollection
        {
            get { return _FinalApprovalCheckListCollection; }
            set { _FinalApprovalCheckListCollection = value; RaisePropertyChanged("FinalApprovalCheckListCollection"); }
        }

        private ICollectionView _ProjectCollection;
        public ICollectionView ProjectCollection
        {
            get { return _ProjectCollection; }
            set { _ProjectCollection = value; RaisePropertyChanged("ProjectCollection"); }
        }

        private ICollectionView _DataGridView;
        public ICollectionView DataGridView
        {
            get { return _DataGridView; }
            set
            {
                _DataGridView = value;
                RaisePropertyChanged("DataGridView");
            }
        }

        private ICollectionView _TaskCollection;
        public ICollectionView TaskCollection
        {
            get { return _TaskCollection; }
            set { _TaskCollection = value; RaisePropertyChanged("TaskCollection"); }
        }
        private ICollectionView _SubCategoryCollection;
        public ICollectionView SubCategoryCollection
        {
            get { return _SubCategoryCollection; }
            set { _SubCategoryCollection = value; RaisePropertyChanged("SubCategoryCollection"); }
        }
        #endregion

        #region StringList Variables

        private List<string> _srtListCustomer;
        public List<string> StringListCustomer
        {
            get { return _srtListCustomer; }
            set
            {
                if (_srtListCustomer != value)
                {
                    _srtListCustomer = value;
                }
            }
        }

        private List<string> _strListEmp;
        public List<string> StrListEmp
        {
            get { return _strListEmp; }
            set
            {
                if (_strListEmp != value)
                {
                    _strListEmp = value;
                }
            }
        }

        private List<string> _strListProCategory;
        public List<string> StrListProCategory
        {
            get { return _strListProCategory; }
            set
            {
                if (_strListProCategory != value)
                {
                    _strListProCategory = value;
                }
            }
        }

        private List<string> _strListRole;
        public List<string> StrListRole
        {
            get { return _strListRole; }
            set
            {
                if (_strListRole != value)
                {
                    _strListRole = value;
                }
            }
        }

        private List<string> _strListCheckList;
        public List<string> StrListCheckList
        {
            get { return _strListCheckList; }
            set
            {
                if (_strListCheckList != value)
                {
                    _strListCheckList = value;
                }
            }
        }

        private List<string> _stringListLocations;
        public List<string> StringListLocations
        {
            get { return _stringListLocations; }
            set
            {
                if (_stringListLocations != value)
                {
                    _stringListLocations = value;
                }
            }
        }

        private List<string> _stringListRefDocNo;
        public List<string> StringListRefDocNo
        {
            get { return _stringListRefDocNo; }
            set
            {
                if (_stringListRefDocNo != value)
                {
                    _stringListRefDocNo = value;
                }
            }
        }

        private List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }

        private List<string> _strListItems;
        public List<string> StrListItems
        {
            get { return _strListItems; }
            set
            {
                if (_strListItems != value)
                {
                    _strListItems = value;
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

        private List<string> _strListTask;
        public List<string> StrListTask
        {
            get { return _strListTask; }
            set
            {
                if (_strListTask != value)
                {
                    _strListTask = value;
                }
            }
        }

        private List<string> _strListPlant;
        public List<string> StrListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                    RaisePropertyChanged("StrListPlant");
                }
            }
        }

        private List<string> _stringListDoneby;
        public List<string> StrListDoneby
        {
            get { return _stringListDoneby; }
            set
            {
                if (_stringListDoneby != value)
                {
                    _stringListDoneby = value;
                }
            }
        }

        #endregion


        #region Relay Commands Declaration

        // Command For Master
        public RelayCommand<object> cmdCustomer { get; private set; }
        public RelayCommand<object> cmdProjectManager { get; private set; }
        public RelayCommand<object> cmdLocation { get; private set; }
        public RelayCommand<object> cmdProjectCategory { get; private set; }
        public RelayCommand<object> cmdProjectSubCategory { get; private set; }
        public RelayCommand<object> cmdRefDocNo { get; private set; }
        public RelayCommand<object> cmdRefDocNoExport { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNo { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdProjectKickoff { get; private set; }

        public GalaSoft.MvvmLight.Command.RelayCommand cmdViewProjectTasks { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdViewProjectTimesheet { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdViewProjectIssues { get; private set; }

        //Command For Project Team Details
        public RelayCommand<object> cmdTeam { get; private set; }
        public RelayCommand<object> cmdRole { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTeam { get; private set; }

        //Command For Project Tasks Details
        public RelayCommand<object> cmdTask { get; private set; }

        //Command For Project Phase Details
        public RelayCommand<object> cmdPhase { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowPhase { get; private set; }
        public RelayCommand<IList> cmdSelectionChangedPhase { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand { get; private set; }

        public RelayCommand<object> cmdDoneByEmp { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTask { get; private set; }

        //Command For Project Final Approval CheckList Details
        public RelayCommand<object> cmdCheckList { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowCheckList { get; private set; }

        //Command For Project Material Details
        public RelayCommand<object> cmdItems { get; private set; }
        public RelayCommand<object> cmdUom { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdMake { get; private set; }
        public RelayCommand<object> cmdModel { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }

        #endregion
        #region .Constructor .
        public PRO_T001_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            EmployeeDetailsEntity = new ObservableCollection<PRO_T001_B>();
            PhaseDetailsEntity = new ObservableCollection<PRO_T001_A>();
            ItemDetailsEntity = new ObservableCollection<PRO_T001_C>();
            TaskDetailsEntity = new ObservableCollection<PRO_T002>();
            FinalApprovalCheckListEntity = new ObservableCollection<PRO_T001_D>();
            FlipGridData = new List<PRO_T001_FLIP>();
            MasterEntity = new PRO_T001();
            MasterEntity.ValidateAsync().Wait();
            kickoff = true;

            TaskDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTask);



            LoadInitialData();

            //if (AppSessionState.TransValueType != null)
            //{
            //    LoadDocumentByDocumentNumber(AppSessionState.TransValueType, "DocumentNo");
            //    AppSessionState.TransValueType = null;
            //    AppSessionState.TransId = null;
            //}

            DefaultValues();

        }
        public PRO_T001_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EmployeeDetailsEntity = new ObservableCollection<PRO_T001_B>();
            PhaseDetailsEntity = new ObservableCollection<PRO_T001_A>();
            ItemDetailsEntity = new ObservableCollection<PRO_T001_C>();
            TaskDetailsEntity = new ObservableCollection<PRO_T002>();
            FinalApprovalCheckListEntity = new ObservableCollection<PRO_T001_D>();
            FlipGridData = new List<PRO_T001_FLIP>();
            MasterEntity = new PRO_T001();
            MasterEntity.ValidateAsync().Wait();
            kickoff = true;

            TaskDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTask);

            LoadInitialData();


            DefaultValues();

        }
        #endregion     

        #region . User Defined Functions .

        private void DefaultValues()
        {
            try
            {
                MasterEntity.doc_cat = "PJ";
                MasterEntity.doc_type = "PJ";
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
                MasterEntity.fin_year = "16-17";
                MasterEntity.posting_period = "8";
                MasterEntity.use_tasks = true;
                MasterEntity.use_timesheet = true;
                MasterEntity.use_issue = true;
                MasterEntity.doc_date = DateTime.UtcNow;
                MasterEntity.start_date = null;
                MasterEntity.dead_date = null;
                MasterEntity.use_appchecklist = true;
                MasterEntity.addactionlog_ts = true;  // Add Action Log in Timesheet by default true
                MasterEntity.ts_code = ts_code_vm;
                //MasterEntity.doc_no = doc_no_vm;
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "PJ" + "!@" + "PJ" + "!@" + (MasterEntity.project_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                // string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T001>(MC, Request, "Project", "PM", "LoadAll", 0, "");

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                #region AutoSuggest Initialisation
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCustomer = new AutoSuggestTextViewModel<dynamic>(MC.PartyList, TheFilter, SuggestedValue, "PartyId", true);
                ASCustomer.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProjectManager = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "EmpId", true);
                ASProjectManager.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjPlant, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().Contains(prefix.ToLower()) || (((SEL_T001_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P)o).reference ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(MC.SonoList, TheFilter, SuggestedValue, "sono", true);
                ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<SEL_T001_P> ordersExport = new List<SEL_T001_P>();
                ordersExport = MC.SonoList.ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().Contains(prefix.ToLower()) || (((SEL_T001_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P)o).reference ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRefDocNoExport = new AutoSuggestTextViewModel<dynamic>(ordersExport, TheFilter, SuggestedValue, "sono", true);
                ASRefDocNoExport.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M001_P)x).cat_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M001_P)o).cat_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M001_P)o).cat_title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProCategory = new AutoSuggestTextViewModel<dynamic>(MC.ProjectCategoryList, TheFilter, SuggestedValue, "cat_id", true);
                ASProCategory.AutoSuggestVM.IsEmptyValueAllowed = true;



                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UomList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M004_P)x).RoleCode);
                TheFilter = (o, prefix) => (((PRO_M004_P)o).RoleCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_M004_P)o).role_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRole = new AutoSuggestTextViewModel<dynamic>(MC.RoleList, TheFilter, SuggestedValue, "RoleCode", "RoleCode", true);
                ASRole.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASRole.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEmployees = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                ASEmployees.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASEmployees.AutoSuggestVM.IsFreeTextAllowed = false;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M003_P)x).phase_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M003_P)o).phase_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M003_P)o).phase_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MC.PhaseList, TheFilter, SuggestedValue, "phase_id", "phase_id", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault3.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M003_P)x).phase_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M003_P)o).phase_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M003_P)o).phase_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPhase = new AutoSuggestTextViewModel<dynamic>(MC.PhaseList, TheFilter, SuggestedValue, "phase_id", "phase_id", true);
                ASPhase.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASPhase.AutoSuggestVM.IsFreeTextAllowed = false;

                //// Added on 29 - 12 - 2016  Autosuggest for tasks need to modify

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P_1)x).title.ToString());
                //TheFilter = (o, prefix) => ((PRO_T002_P_1)o).title.ToString().Contains(prefix.ToLower());
                //ASTask = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "title", "title");
                //ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASTask.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M005_P)x).point_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M005_P)o).point_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M005_P)o).point_description ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MC.ProjectCheckList, TheFilter, SuggestedValue, "point_id", "point_id", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M005_P)x).point_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M005_P)o).point_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M005_P)o).point_description ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCheckList = new AutoSuggestTextViewModel<dynamic>(MC.ProjectCheckList, TheFilter, SuggestedValue, "point_id", "point_id", true);
                ASCheckList.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASCheckList.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M031_P)x).value_code.ToString());
                TheFilter = (o, prefix) => (((ADM_M031_P)o).value_code.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M031_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASMake = new AutoSuggestTextViewModel<dynamic>(MC.MakeList, TheFilter, SuggestedValue, "value_code", "value_code", true);
                ASMake.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASMake.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M031_P)x).value_code.ToString());
                TheFilter = (o, prefix) => (((ADM_M031_P)o).value_code.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M031_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASModel = new AutoSuggestTextViewModel<dynamic>(MC.ModelList, TheFilter, SuggestedValue, "value_code", "value_code", true);
                ASModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASModel.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                #region Command Initialisation

                cmdLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                cmdCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items, NewRecord); });
                cmdProjectManager = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectManager(items); });
                cmdLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdRefDocNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDocNo(items); });
                cmdRefDocNoExport = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDocNoExport(items); });
                cmdProjectKickoff = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ProjectKickOff(); });
                cmdProjectCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectCategory(items); });
                cmdProjectSubCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectSubCategory(items); });

                cmdViewProjectTasks = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewProjectTasks(); });
                cmdViewProjectTimesheet = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewProjectTimesheet(); });
                cmdViewProjectIssues = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ViewProjectIssues(); });

                cmdTeam = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEmployee(cmdPara, true, true, true); });
                cmdItems = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                cmdUom = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                cmdRole = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRole(cmdPara, false, true, true); });
                cmdPhase = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPhaseDetails(cmdPara, true, true, true); });
                //SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });

                cmdTask = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTask(cmdPara, true, true, true); });

                cmdDoneByEmp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDoneByEmp(cmdPara, false, true, true); });

                cmdCheckList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertFinalApprovalCheckListDetails(cmdPara, true, true, true); });

                cmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
                cmdDeleteDataGridRowTeam = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Team(cmdPara); });// confirm assignment
                cmdDeleteDataGridRowPhase = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Phase(cmdPara); });// confirm assignment
                cmdDeleteDataGridRowCheckList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_CheckListPoint(cmdPara); });// confirm assignment
                cmdDeleteDataGridRowTask = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Task(cmdPara); });// confirm assignment

                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMake(items); });
                cmdModel = new RelayCommand<object>(items => { if (items == null) { return; } InsertModel(items); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                //cmdKickOff = new RelayCommand(() => { GetStarted(); });
                #endregion
                FlipGridData = MC.ProjectList;

                StrListProCategory = MC.ProjectCategoryList.Select(x => x.cat_id.ToString()).ToList();

                StringListCustomer = MC.PartyList.Select(x => x.PartyId).ToList();

                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();
                StringListRefDocNo = MC.SonoList.Select(x => x.sono).ToList();
                StrListPlant = ObjPlant.Select(x => x.location_Id).ToList();


                TeamCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList.ToList());
                TeamCollection.Filter = new Predicate<object>(FilterEmployeeTeam);
                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();

                PhaseCollection = CollectionViewSource.GetDefaultView(MC.PhaseList.ToList());
                PhaseCollection.Filter = new Predicate<object>(FilterPhase);
                StrListPhase = MC.PhaseList.Select(x => x.phase_name).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList.ToList());
                ItemCollection.Filter = new Predicate<object>(FilterItem);
                StrListItems = MC.ItemList.Select(x => x.ItemCode).ToList();

                FinalApprovalCheckListCollection = CollectionViewSource.GetDefaultView(MC.ProjectCheckList.ToList());
                FinalApprovalCheckListCollection.Filter = new Predicate<object>(FilterCheckList);
                StrListCheckList = MC.ProjectCheckList.Select(x => x.point_id.ToString()).ToList();

                //Added on 29-12-2016
                TaskCollection = CollectionViewSource.GetDefaultView(MC.TaskList.ToList());
                TaskCollection.Filter = new Predicate<object>(FilterTask);
                StrListTask = MC.TaskList.Select(x => x.title).ToList();

                ProjectCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                ProjectCollection.Filter = new Predicate<object>(FilterProject);

                StringListUOM = MC.UomList.Select(x => x.unit_code).ToList();
                StrListRole = MC.RoleList.Select(x => x.role_name).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                store_location = (from o in StoreLocList
                                  where o.location_Id == AppSessionState.location_Id && o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
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
        private void ProjectKickOff()
        {
            try
            {
                if (MasterEntity.project_id != null && MasterEntity.project_id != "")
                {
                    MasterEntity.t_status = "018";
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation: Cannot Start Project";
                    showMessageService.Text = String.Format("Please Save the Project First and then Try Starting it...!!!", this.Title);
                    showMessageService.ShowMessage();
                }

                //string Request = "KickOff" + "!@" + MasterEntity.project_id;
                //MCtemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T001>(MCtemp, Request, "Project", "PM", "KickOff", 0, MasterEntity.project_id);

                //string Msg = "To Start The Project IT Must Meet Following Criteria :";

                //if (MCtemp.EmpCount <= 0)
                //{
                //    Msg = Msg + "\n=>Project Must Have At Least One Team Member.";
                //}

                //if (MCtemp.PhaseCount <= 0)
                //{
                //    Msg = Msg + "\n=>Project Must Have a Phase Which is With Sequence 1.";
                //}

                //if (MCtemp.TaskCount <= 0)
                //{
                //    Msg = Msg + "\n=>First Phase(Phase with Sequence 1) of This Project Must Have At least One Task Created.";
                //}

                //if (MCtemp.EmpCount > 0 && MCtemp.PhaseCount > 0 && MCtemp.TaskCount > 0)
                //{
                //    Msg = "Project Started Successfully.";
                //    MasterEntity.t_status = "Inprocess";

                //    ObjectSerializationService objSer = new ObjectSerializationService();
                //    MasterEntity.XmlDataDocument_PRO_T001_A = objSer.ObjectToXML(PhaseDetailsEntity);
                //    MasterEntity.XmlDataDocument_PRO_T001_B = objSer.ObjectToXML(EmployeeDetailsEntity);
                //    MasterEntity.XmlDataDocument_PRO_T001_C = objSer.ObjectToXML(ItemDetailsEntity);

                //    MasterEntity = repository.UpdateWithReturnDomainObject<PRO_T001>(MasterEntity, "Project", "PM");
                //    kickoff = false;
                //}

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = Msg;
                //showMessageService.ShowMessage();



                //if (MasterEntity.XmlDataDocument_PRO_T001_A != null)
                //{
                //    MC.ProjectPhaseList = (ObservableCollection<PRO_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T001_A, MC.ProjectPhaseList);
                //}
                //else
                //{
                //    MC.ProjectPhaseList = new ObservableCollection<PRO_T001_A>();
                //}
                //PhaseDetailsEntity = MC.ProjectPhaseList;
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
                result.Add("prepare_by", AppSessionState.Name);
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
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {

                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
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
        private void InsertCustomer(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.customer_id = POPUPEntityObject.PartyId;
                    MasterEntity.customernm = POPUPEntityObject.PartyNm;
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
        private void InsertProjectManager(object InputValue)
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
                            { POPUPEntityObject = MC.EmployeeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.project_manager = POPUPEntityObject.EmpId;
                    MasterEntity.projectmanagernm = POPUPEntityObject.EmpLName;
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
        private void InsertProjectCategory(object InputValue)
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
                            { POPUPEntityObject = MC.ProjectCategoryList.Where(x => x.cat_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                    var ProjectSubCategoryWiseList = (from o in MC.ProjectSubCategoryList
                                                      where o.cat_id == MasterEntity.cat_id
                                                      select o).ToList();


                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M001_A_P)x).sub_cat_code.ToString());
                    TheFilter = (o, prefix) => (((PRO_M001_A_P)o).sub_cat_code.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M001_A_P)o).sub_cat ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASProSubCategory = new AutoSuggestTextViewModel<dynamic>(ProjectSubCategoryWiseList, TheFilter, SuggestedValue, "sub_cat_code", true);
                    ASProSubCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                    SubCategoryCollection = CollectionViewSource.GetDefaultView(ProjectSubCategoryWiseList);
                    SubCategoryCollection.Filter = new Predicate<object>(FilterSubCategory);

                    //Set Default values if count is 1   
                    if (ProjectSubCategoryWiseList != null && ProjectSubCategoryWiseList.Count == 1)
                    {
                        MasterEntity.para1 = ProjectSubCategoryWiseList[0].sub_cat_code;
                        MasterEntity.sub_cat = ProjectSubCategoryWiseList[0].sub_cat;
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
        private void InsertProjectSubCategory(object InputValue)
        {
            string stringSubcatCode = "";
            string stringSubcat = "";

            MasterEntity.para1 = "";
            foreach (PRO_M001_A_P temp in MC.ProjectSubCategoryList)
            {
                if (temp.Select == true)
                {
                    stringSubcatCode = stringSubcatCode + "," + temp.sub_cat_code;
                    stringSubcat = stringSubcat + "," + temp.sub_cat;

                }
            }
            MasterEntity.para1 = stringSubcatCode.ToString().TrimStart(new char[] { ',' });
            MasterEntity.sub_cat = stringSubcat.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertRefDocNo(object InputValue)
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
                            {
                                POPUPEntityObject = MC.SonoList.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.ref_doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.ref_doc_no = POPUPEntityObject.sono;
                    MasterEntity.customer_id = POPUPEntityObject.PartyId;
                    MasterEntity.customernm = POPUPEntityObject.party_name;
                    MasterEntity.project_manager = POPUPEntityObject.EmpId;
                    MasterEntity.projectmanagernm = POPUPEntityObject.EmpNm;
                    MasterEntity.pcode_1 = POPUPEntityObject.reference;
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
        private void InsertRefDocNoExport(object InputValue)
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
                            {
                                POPUPEntityObject = MC.SonoList.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterEntity.work_order = POPUPEntityObject.sono;
                    MasterEntity.pcode_2 = POPUPEntityObject.reference;
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
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PRO_T001_FLIP ParameterEntityObject = null;
                MasterEntity = new PRO_T001();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    //Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + "PJ" + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.project_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");

                    if (MCtemp.ProjectMasterList.Count > 0)
                    {
                        MasterEntity = MCtemp.ProjectMasterList[0];
                    }

                    EmployeeDetailsEntity = MCtemp.ProjectEmployeeList;
                    ItemDetailsEntity = MCtemp.ProjectItemList;
                    PhaseDetailsEntity = MCtemp.ProjectPhaseList;
                    FinalApprovalCheckListEntity = MCtemp.ProjectApprovalCheckList;
                    TaskDetailsEntity = MCtemp.ProjectTaskList;

                    //Added Code to solve deletion/updation datagrid index issue
                    int count = TaskDetailsEntity.Count;
                    if (TaskDetailsEntity.Count > 0)
                    {
                        for (mn = 0; mn <= count; mn++)
                        {
                            dgSelectedIndexTask = mn;
                        }
                    }

                    AttachmentCollection = MCtemp.AttachmentData;

                    if (MCtemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCtemp.AttachmentData;
                    }
                    else
                    {
                        MCtemp.AttachmentData = new List<COM_T003>();
                    }

                    NewRecord = false;
                }
                else if (((IEnumerable)ParameterObject).Cast<PRO_T001_FLIP>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_T001_FLIP>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + "PJ" + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.project_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                    //Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.project_id;
                    NewRecord = false;

                    MCtemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T001>(MCtemp, Request, "Project", "PM", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCtemp.ProjectMasterList.Count > 0)
                    {
                        MasterEntity = MCtemp.ProjectMasterList[0];
                    }

                    EmployeeDetailsEntity = MCtemp.ProjectEmployeeList;
                    ItemDetailsEntity = MCtemp.ProjectItemList;
                    PhaseDetailsEntity = MCtemp.ProjectPhaseList;
                    FinalApprovalCheckListEntity = MCtemp.ProjectApprovalCheckList;
                    TaskDetailsEntity = MCtemp.ProjectTaskList;

                    //Added Code to solve deletion/updation datagrid index issue
                    int count = TaskDetailsEntity.Count;
                    if (TaskDetailsEntity.Count > 0)
                    {
                        for (mn = 0; mn <= count; mn++)
                        {
                            dgSelectedIndexTask = mn;
                        }
                    }


                    AttachmentCollection = MCtemp.AttachmentData;

                    if (MCtemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCtemp.AttachmentData;
                    }
                    else
                    {
                        MCtemp.AttachmentData = new List<COM_T003>();
                    }

                }

                if (EmployeeDetailsEntity != null)
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                    TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASDefault5 = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                    ASDefault5.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASDefault5.AutoSuggestVM.IsFreeTextAllowed = true;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                    TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASAssignedTo = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                    ASAssignedTo.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASAssignedTo.AutoSuggestVM.IsFreeTextAllowed = false;

                    StrListDoneby = EmployeeDetailsEntity.Where(x => x.active == true).Select(x => x.EmpId).ToList();

                    //Added on 5-1-2017
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P_1)x).title.ToString());
                    TheFilter = (o, prefix) => (((PRO_T002_P_1)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASTask = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "title", "title", true);
                    ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASAssignedTo.AutoSuggestVM.IsFreeTextAllowed = false;

                    StrListTask = MC.TaskList.Select(x => x.title).ToList();
                }
                MasterEntity.ts_code = ts_code_vm;
                SelectedTabControlIndex = 1;
                var msg = new NotificationMessage("PRO_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);

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
            ASCustomer.AutoSuggestVM.Suggestion = MC.PartyList.Find(x => x.PartyId == MasterEntity.customer_id);
            ASPlant.AutoSuggestVM.Suggestion = ObjPlant.Find(x => x.location_Id == MasterEntity.location_Id);
            ASRefDocNo.AutoSuggestVM.Suggestion = MC.SonoList.Find(x => x.sono == MasterEntity.ref_doc_no);
            ASProjectManager.AutoSuggestVM.Suggestion = MC.EmployeeList.Find(x => x.EmpId == MasterEntity.project_manager);
        }
        private void ViewProjectTasks()
        {
            try
            {
                SYS_AUTH userAuth = new SYS_AUTH();

                string TransactionCode = MC.Doc_typeList.Where(x => x.doc_type == "TK").Select(x => x.TranCode).FirstOrDefault();


                if (MasterEntity != null && MasterEntity.project_id != null && MasterEntity.project_id != "")
                {
                    var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == TransactionCode).FirstOrDefault();
                    userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    AppSessionState.ViewTitle = userAuth.ts_name;
                    AppSessionState.TransValueType = MasterEntity.project_id;
                    //AppSessionState.TransId = userAuth.menu_code.ToString();

                    if (userAuth.class_file != null && userAuth.class_file != "")
                    {
                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType(userAuth.class_file);
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, TransactionCode);
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
        private void ViewProjectTimesheet()
        {
            try
            {
                SYS_AUTH userAuth = new SYS_AUTH();

                string TransactionCode = MC.Doc_typeList.Where(x => x.doc_type == "TS").Select(x => x.TranCode).FirstOrDefault();

                if (MasterEntity != null && MasterEntity.project_id != null && MasterEntity.project_id != "")
                {
                    var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == TransactionCode).FirstOrDefault();
                    userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    AppSessionState.ViewTitle = userAuth.ts_name;
                    AppSessionState.TransValueType = MasterEntity.project_id;
                    //AppSessionState.TransId = userAuth.menu_code.ToString();

                    if (userAuth.class_file != null && userAuth.class_file != "")
                    {
                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType(userAuth.class_file);
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, TransactionCode);
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
        private void ViewProjectIssues()
        {
            try
            {
                SYS_AUTH userAuth = new SYS_AUTH();

                string TransactionCode = MC.Doc_typeList.Where(x => x.doc_type == "IS").Select(x => x.TranCode).FirstOrDefault();


                if (MasterEntity != null && MasterEntity.project_id != null && MasterEntity.project_id != "")
                {
                    var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == TransactionCode).FirstOrDefault();
                    userAuth = docdetails;
                    //AppSessionState.UserAuthSingle = userAuth;
                    AppSessionState.ViewTitle = userAuth.ts_name;
                    AppSessionState.TransValueType = MasterEntity.project_id;
                    //AppSessionState.TransId = userAuth.menu_code.ToString();

                    if (userAuth.class_file != null && userAuth.class_file != "")
                    {
                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType(userAuth.class_file);
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, TransactionCode);
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

        private void CollectionChangedNotifyForTask(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                ////////////////////////////////////Temp Test
                //if (e.NewItems != null && e.NewItems.Count != 0)
                //    foreach (PUR_T004_B item in e.NewItems)
                //        item.PropertyChanged += this.Schedule_PropertyChanged;

                //if (e.OldItems != null && e.OldItems.Count != 0)
                //    foreach (PUR_T004_B item in e.OldItems)
                //        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && TaskDetailsEntity.Count > 0 && dgSelectedIndexPhase != -1 && PhaseDetailsEntity != null && PhaseDetailsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (PRO_T002 item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        if (dgSelectedIndexTask <= TaskDetailsEntity.Count)
                        {
                            item.project_id = MasterEntity.project_id;
                            item.phase_id = PhaseDetailsEntity[dgSelectedIndexPhase].phase_id;
                            item.doc_date = DateTime.UtcNow;
                            item.t_status = "001";
                            item.active = true;
                            item.doc_cat = "TK";
                            item.doc_type = "TK";
                            item.comp_code = AppSessionState.comp_code;
                            item.client = AppSessionState.client;
                            item.location_Id = AppSessionState.location_Id;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                            TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASDefault5 = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                            ASDefault5.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDefault5.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                            TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASAssignedTo = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                            ASAssignedTo.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASAssignedTo.AutoSuggestVM.IsFreeTextAllowed = false;

                            //Added on 5-1-2017
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P_1)x).title.ToString());
                            TheFilter = (o, prefix) => (((PRO_T002_P_1)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASTask = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "title", "title", true);
                            ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;

                            StrListTask = MC.TaskList.Select(x => x.title).ToList();
                        }

                        //      item.PropertyChanged += EntityViewModelPropertyChanged;
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

        //A
        private void InsertPhaseDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_M003_P POPUPEntityObject = null;
                dgSelectedIndexPhase = dgSelectedIndexPhase;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PhaseList.Where(x => x.phase_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M003_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = PhaseDetailsEntity.Where(X => X.phase_id == POPUPEntityObject.phase_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = PhaseDetailsEntity.IndexOf(PhaseDetailsEntity.Where(X => X.phase_id == POPUPEntityObject.phase_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && PhaseDetailsEntity.Count == dgSelectedIndexPhase)
                    {
                        PhaseDetailsEntity.Add(new PRO_T001_A()
                        {
                            phase_id = POPUPEntityObject.phase_id,
                            phasenm = POPUPEntityObject.phase_name,
                            active = true,
                            t_status = "001",
                            start_date = DateTime.Now,
                            dead_date = DateTime.Now,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2

                        });

                    }
                    else if (dgSelectedIndexPhase >= 0 && PhaseDetailsEntity.Count > dgSelectedIndexPhase) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (PhaseDetailsEntity[dgSelectedIndexPhase].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            PhaseDetailsEntity[dgSelectedIndexPhase].phase_id = POPUPEntityObject.phase_id;
                            PhaseDetailsEntity[dgSelectedIndexPhase].phasenm = POPUPEntityObject.phase_name;
                            PhaseDetailsEntity[dgSelectedIndexPhase].active = true;
                            PhaseDetailsEntity[dgSelectedIndexPhase].t_status = "001";
                            PhaseDetailsEntity[dgSelectedIndexPhase].start_date = DateTime.Now;
                            PhaseDetailsEntity[dgSelectedIndexPhase].dead_date = DateTime.Now;
                            PhaseDetailsEntity[dgSelectedIndexPhase].add_by = AppSessionState.UserID;
                            PhaseDetailsEntity[dgSelectedIndexPhase].editby = AppSessionState.UserID;
                            PhaseDetailsEntity[dgSelectedIndexPhase].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;

                        }
                        else if (PhaseDetailsEntity[dgSelectedIndexPhase].phase_id != POPUPEntityObject.phase_id)
                        {
                            PhaseDetailsEntity[dgSelectedIndexPhase].phase_id = "";
                            PhaseDetailsEntity[dgSelectedIndexPhase].phasenm = "";

                        }
                    }
                }
                #region Clear Empty Row
                PRO_T001_A newObj = new PRO_T001_A();
                for (int i = PhaseDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = PhaseDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (PhaseDetailsEntity[i].ComparePropertiesTo(newObj) == true && PhaseDetailsEntity.Count > 1)
                    {
                        PhaseDetailsEntity.RemoveAt(i);
                        if (PhaseDetailsEntity.Count == 0)
                        {
                            PhaseDetailsEntity.Add(newObj);
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
        private void DeleteDataGridRow_Phase(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (PhaseDetailsEntity.Count > i && PhaseDetailsEntity[i].id == 0)
                {
                    // First Its Batches Will be removed And then Item  
                    ObservableCollection<PRO_T002> tasktemp = TaskDetailsEntity;

                    for (int j = TaskDetailsEntity.Count - 1; j >= 0; j--)
                    {
                        if (PhaseDetailsEntity[i].phase_id == TaskDetailsEntity[j].phase_id)
                        {
                            TaskDetailsEntity.Remove(TaskDetailsEntity[j]);
                        }
                    }

                    PhaseDetailsEntity.RemoveAt(i);
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
        private void FilterTaskDataGrid()
        {
            try
            {
                if (TaskDetailsEntity != null && TaskDetailsEntity.Count > 0 && dgSelectedIndexPhase >= 0 && PhaseDetailsEntity != null && PhaseDetailsEntity.Count > 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(TaskDetailsEntity);

                    DataGridView.Filter = adv => ((PRO_T002)adv).phase_id.Equals(PhaseDetailsEntity[dgSelectedIndexPhase].phase_id);

                    DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }

        //B
        private void InsertEmployee(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                dgSelectedIndexEmp = dgSelectedIndexEmp;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmployeeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = EmployeeDetailsEntity.Where(X => X.EmpId == POPUPEntityObject.EmpId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = EmployeeDetailsEntity.IndexOf(EmployeeDetailsEntity.Where(X => X.EmpId == POPUPEntityObject.EmpId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && EmployeeDetailsEntity.Count == dgSelectedIndexEmp)
                    {
                        EmployeeDetailsEntity.Add(new PRO_T001_B()
                        {
                            EmpId = POPUPEntityObject.EmpId,
                            empname = POPUPEntityObject.EmpLName,
                            Emp_Type = POPUPEntityObject.emp_type,
                            active = true,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2
                        });
                    }
                    else if (dgSelectedIndexEmp >= 0 && EmployeeDetailsEntity.Count > dgSelectedIndexEmp) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (EmployeeDetailsEntity[dgSelectedIndexEmp].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            EmployeeDetailsEntity[dgSelectedIndexEmp].EmpId = POPUPEntityObject.EmpId;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].empname = POPUPEntityObject.EmpLName;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].Emp_Type = POPUPEntityObject.emp_type;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].active = true;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].add_by = AppSessionState.UserID;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].editby = AppSessionState.UserID;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                        }
                        else if (EmployeeDetailsEntity[dgSelectedIndexEmp].EmpId != POPUPEntityObject.EmpId)
                        {
                            EmployeeDetailsEntity[dgSelectedIndexEmp].EmpId = "";
                            EmployeeDetailsEntity[dgSelectedIndexEmp].empname = "";
                        }
                    }

                    if (EmployeeDetailsEntity != null)
                    {
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                        TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASDefault5 = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                        ASDefault5.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDefault5.AutoSuggestVM.IsFreeTextAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_B)x).EmpId);
                        TheFilter = (o, prefix) => (((PRO_T001_B)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRO_T001_B)o).empname ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASAssignedTo = new AutoSuggestTextViewModel<dynamic>(EmployeeDetailsEntity, TheFilter, SuggestedValue, "EmpId", "EmpId", true);
                        ASAssignedTo.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASAssignedTo.AutoSuggestVM.IsFreeTextAllowed = false;

                        StrListDoneby = EmployeeDetailsEntity.Where(x => x.active == true).Select(x => x.EmpId).ToList();

                    }
                }
                #region Clear Empty Row
                PRO_T001_B newObj = new PRO_T001_B();
                for (int i = EmployeeDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = EmployeeDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (EmployeeDetailsEntity[i].ComparePropertiesTo(newObj) == true && EmployeeDetailsEntity.Count > 1)
                    {
                        EmployeeDetailsEntity.RemoveAt(i);
                        if (EmployeeDetailsEntity.Count == 0)
                        {
                            EmployeeDetailsEntity.Add(newObj);
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
        private void InsertRole(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_M004_P POPUPEntityObject = null;
                dgSelectedIndexEmp = dgSelectedIndexEmp;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RoleList.Where(x => x.RoleCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PRO_M004_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M004_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = EmployeeDetailsEntity.Where(X => X.RoleCode == POPUPEntityObject.RoleCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = EmployeeDetailsEntity.IndexOf(EmployeeDetailsEntity.Where(X => X.RoleCode == POPUPEntityObject.RoleCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexEmp >= 0 && EmployeeDetailsEntity.Count > dgSelectedIndexEmp) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (EmployeeDetailsEntity[dgSelectedIndexEmp].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            EmployeeDetailsEntity[dgSelectedIndexEmp].RoleCode = POPUPEntityObject.RoleCode;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].role_name = POPUPEntityObject.role_name;
                        }
                        else if (EmployeeDetailsEntity[dgSelectedIndexEmp].RoleCode != POPUPEntityObject.RoleCode)
                        {
                            EmployeeDetailsEntity[dgSelectedIndexEmp].RoleCode = POPUPEntityObject.RoleCode;
                            EmployeeDetailsEntity[dgSelectedIndexEmp].role_name = POPUPEntityObject.role_name;
                        }
                    }
                }
                #region Clear Empty Row
                PRO_T001_B newObj = new PRO_T001_B();
                for (int i = EmployeeDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = EmployeeDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (EmployeeDetailsEntity[i].ComparePropertiesTo(newObj) == true && EmployeeDetailsEntity.Count > 1)
                    {
                        EmployeeDetailsEntity.RemoveAt(i);
                        if (EmployeeDetailsEntity.Count == 0)
                        {
                            EmployeeDetailsEntity.Add(newObj);
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
        private void DeleteDataGridRow_Team(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (EmployeeDetailsEntity.Count > i && EmployeeDetailsEntity[dgSelectedIndexEmp].id == 0)
                {
                    EmployeeDetailsEntity.RemoveAt(i);
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

        //C
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemDetailsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemDetailsEntity.Add(new PRO_T001_C()
                        {

                            ItemCode = POPUPEntityObject.ItemCode,
                            itemname = POPUPEntityObject.ItemName,
                            unit_code = POPUPEntityObject.unit_code,
                            active = true,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,

                            store_code = store_location,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2
                        });

                    }
                    else if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemDetailsEntity[dgSelectedIndexItem].itemname = POPUPEntityObject.ItemName;
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                            ItemDetailsEntity[dgSelectedIndexItem].active = true;
                            ItemDetailsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            ItemDetailsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                            ItemDetailsEntity[dgSelectedIndexItem].store_code = store_location;
                            ItemDetailsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            ItemDetailsEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                            ItemDetailsEntity[dgSelectedIndexItem].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                            ItemDetailsEntity[dgSelectedIndexItem].client = AppSessionState.client;

                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemDetailsEntity[dgSelectedIndexItem].itemname = "";

                        }
                    }
                }
                #region Clear Empty Row
                PRO_T001_C newObj = new PRO_T001_C();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UomList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                PRO_T001_C newObj = new PRO_T001_C();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemDetailsEntity.Count > i && ItemDetailsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemDetailsEntity.RemoveAt(i);
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

        //D
        private void InsertFinalApprovalCheckListDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_M005_P POPUPEntityObject = null;
                dgSelectedIndexApprovalCheckList = dgSelectedIndexApprovalCheckList;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProjectCheckList.Where(x => x.point_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M005_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = FinalApprovalCheckListEntity.Where(X => X.point_id == POPUPEntityObject.point_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = FinalApprovalCheckListEntity.IndexOf(FinalApprovalCheckListEntity.Where(X => X.point_id == POPUPEntityObject.point_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && FinalApprovalCheckListEntity.Count == dgSelectedIndexApprovalCheckList)
                    {
                        FinalApprovalCheckListEntity.Add(new PRO_T001_D()
                        {
                            point_id = POPUPEntityObject.point_id,
                            point_description = POPUPEntityObject.point_description,
                            active = true,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2

                        });

                    }
                    else if (dgSelectedIndexApprovalCheckList >= 0 && FinalApprovalCheckListEntity.Count > dgSelectedIndexApprovalCheckList) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].point_id = POPUPEntityObject.point_id;
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].point_description = POPUPEntityObject.point_description;
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].active = true;
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].add_by = AppSessionState.UserID;
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].editby = AppSessionState.UserID;
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;

                        }
                        else if (FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].point_id != POPUPEntityObject.point_id)
                        {
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].point_id = "";
                            FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].point_description = "";

                        }
                    }
                }
                #region Clear Empty Row
                PRO_T001_D newObj = new PRO_T001_D();
                for (int i = FinalApprovalCheckListEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = FinalApprovalCheckListEntity[i].ComparePropertiesTo(newObj);
                    if (FinalApprovalCheckListEntity[i].ComparePropertiesTo(newObj) == true && FinalApprovalCheckListEntity.Count > 1)
                    {
                        FinalApprovalCheckListEntity.RemoveAt(i);
                        if (FinalApprovalCheckListEntity.Count == 0)
                        {
                            FinalApprovalCheckListEntity.Add(newObj);
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
        private void DeleteDataGridRow_CheckListPoint(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (FinalApprovalCheckListEntity.Count > i && FinalApprovalCheckListEntity[dgSelectedIndexApprovalCheckList].id == 0)
                {
                    FinalApprovalCheckListEntity.RemoveAt(i);
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
            // Technical Problem of Index is comming due to filtering Collection So Currently Command is Commented and this method is not used
            try
            {
                string Request = "";
                PRO_T001_B POPUPEntityObject = null;
                dgSelectedIndexTask = dgSelectedIndexTask;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = EmployeeDetailsEntity.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PRO_T001_B>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_B>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = TaskDetailsEntity.Where(X => X.task_id == POPUPEntityObject.EmpId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = TaskDetailsEntity.IndexOf(TaskDetailsEntity.Where(X => X.task_id == POPUPEntityObject.EmpId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexTask >= 0 && EmployeeDetailsEntity.Count > dgSelectedIndexTask) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if ((TaskDetailsEntity[dgSelectedIndexTask].task_id == null || TaskDetailsEntity[dgSelectedIndexTask].task_id == "") && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            TaskDetailsEntity[dgSelectedIndexTask].EmpId = POPUPEntityObject.EmpId;
                            TaskDetailsEntity[dgSelectedIndexTask].assignto_name = POPUPEntityObject.empname;
                        }
                        else if (TaskDetailsEntity[dgSelectedIndexTask].EmpId != POPUPEntityObject.EmpId)
                        {
                            TaskDetailsEntity[dgSelectedIndexTask].EmpId = POPUPEntityObject.EmpId;
                            TaskDetailsEntity[dgSelectedIndexTask].assignto_name = POPUPEntityObject.empname;
                        }
                    }
                }
                #region Clear Empty Row
                PRO_T002 newObj = new PRO_T002();
                for (int i = TaskDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = TaskDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (TaskDetailsEntity[i].ComparePropertiesTo(newObj) == true && EmployeeDetailsEntity.Count > 1)
                    {
                        TaskDetailsEntity.RemoveAt(i);
                        if (TaskDetailsEntity.Count == 0)
                        {
                            TaskDetailsEntity.Add(newObj);
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
        private void DeleteDataGridRow_Task(object InputValue)
        {
            try
            {
                PRO_T002 POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<PRO_T002>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T002>().ToList()[0];
                }
                List<PRO_T002> temp = TaskDetailsEntity.ToList();
                foreach (var a in temp)
                {
                    if ((a.task_id == null || a.task_id == "") && a.SrNo == POPUPEntityObject.SrNo)
                    {
                        TaskDetailsEntity.Remove(a);
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

        private void ItemActiveInActiveMethod(object InputValue)
        {
            try
            {
                int i = (int)InputValue;

                if (PhaseDetailsEntity.Count >= i && PhaseDetailsEntity[i].id != 0)
                {
                    if (PhaseDetailsEntity[i].active == false)
                    {
                        foreach (var item in TaskDetailsEntity)
                        {
                            if (item.phase_id == PhaseDetailsEntity[i].phase_id && item.active == true)
                            {
                                item.active = false;
                            }
                        }
                    }
                }
                else if (PhaseDetailsEntity[i].id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Phase {0} is Unsaved . It is Recommanded to Delete This Phase rather than inactivating it ", this.Title);
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

        private void InsertTask(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_T002_P_1 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaskList.Where(x => (x.title.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true)).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T002_P_1>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    List<PRO_T002> temp = new List<PRO_T002>();
                    temp = TaskDetailsEntity.ToList();
                    foreach (var o in TaskDetailsEntity)
                    {
                        if (o.phase_id != PhaseDetailsEntity[dgSelectedIndexPhase].phase_id)
                        {
                            temp.Remove(o);
                        }
                    }



                    if (NewRow == true && (AllowDuplicate == true) && temp.Count == dgSelectedIndexTask)
                    {
                        TaskDetailsEntity.Add(new PRO_T002()
                        {
                            title = POPUPEntityObject.title,
                            t_description = POPUPEntityObject.t_description,
                            t_status = "001",
                            start_date = DateTime.Now,
                            dead_date = DateTime.Now,
                            active = true,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2,
                            task_code = POPUPEntityObject.task_code,
                            SrNo = mn++
                        });
                    }
                    else if ((dgSelectedIndexTask >= 0) && (TaskDetailsEntity.Count > dgSelectedIndexTask)) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        foreach (var a in TaskDetailsEntity)
                        {

                            if ((temp[dgSelectedIndexTask].phase_id == a.phase_id) && (a.task_id == null) && (a.SrNo == temp[dgSelectedIndexTask].SrNo))
                            {
                                a.title = POPUPEntityObject.title;
                                a.t_description = POPUPEntityObject.t_description;
                                a.start_date = DateTime.Now;
                                a.dead_date = DateTime.Now;
                                a.active = true;
                                a.add_by = AppSessionState.UserID;
                                a.editby = AppSessionState.UserID;
                                a.user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                                a.task_code = POPUPEntityObject.task_code;
                            }
                            else if (temp[dgSelectedIndexTask].phase_id == TaskDetailsEntity[dgSelectedIndexTask].phase_id && TaskDetailsEntity[dgSelectedIndexTask].task_id != null)
                            {
                                a.title = "";
                                a.t_description = "";
                            }
                        }

                    }
                    //Changes in logic As per Client Requirment
                    //if (TaskDetailsEntity[dgSelectedIndexTask].task_id == "0" && (AllowDuplicate == true)) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    //{
                    //    TaskDetailsEntity[dgSelectedIndexTask].title = POPUPEntityObject.title;
                    //    TaskDetailsEntity[dgSelectedIndexTask].t_description = POPUPEntityObject.t_description;
                    //    TaskDetailsEntity[dgSelectedIndexTask].start_date = DateTime.Now;
                    //    TaskDetailsEntity[dgSelectedIndexTask].dead_date = DateTime.Now;
                    //    TaskDetailsEntity[dgSelectedIndexTask].active = true;
                    //    TaskDetailsEntity[dgSelectedIndexTask].add_by = AppSessionState.UserID;
                    //    TaskDetailsEntity[dgSelectedIndexTask].editby = AppSessionState.UserID;
                    //    TaskDetailsEntity[dgSelectedIndexTask].user_source1 = AppSessionState.UserSource1 + "," + AppSessionState.UserSource2;
                    //}
                    //else if (TaskDetailsEntity[dgSelectedIndexTask].title != POPUPEntityObject.title)
                    //{
                    //    TaskDetailsEntity[dgSelectedIndexTask].title = "";
                    //    TaskDetailsEntity[dgSelectedIndexTask].t_description = "";
                    //}
                    //}

                    // if (TaskDetailsEntity != null)
                    //  {


                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T002_P_1)x).title.ToString());
                    //TheFilter = (o, prefix) => ((PRO_T002_P_1)o).title.ToString().StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                    //ASTask = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "title", "title");
                    //ASTask.AutoSuggestVM.IsEmptyValueAllowed = true;
                    //ASTask.AutoSuggestVM.IsFreeTextAllowed = false;

                    //StrListTask = TaskDetailsEntity.Where(x => x.active == true).Select(x => x.title).ToList();

                    // }
                }

                #region Clear Empty Row
                PRO_T002 newObj = new PRO_T002();
                for (int i = TaskDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = TaskDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (TaskDetailsEntity[i].ComparePropertiesTo(newObj) == true && TaskDetailsEntity.Count > 1)
                    {
                        TaskDetailsEntity.RemoveAt(i);
                        if (TaskDetailsEntity.Count == 0)
                        {
                            TaskDetailsEntity.Add(newObj);
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
        private void InsertMake(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M031_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.MakeList.Where(x => x.value_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M031_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.para2 = POPUPEntityObject.value_code;
                    MasterEntity.make = POPUPEntityObject.parametervalue;
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
        private void InsertModel(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M031_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ModelList.Where(x => x.value_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M031_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.para3 = POPUPEntityObject.value_code;
                    MasterEntity.model = POPUPEntityObject.parametervalue;
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
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            PRO_T001_D EntityObjectParameter = new PRO_T001_D();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<PRO_T001_D>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (AppSessionState.location_Id) + "!@!@!@" + EntityObjectParameter.project_id + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.point_id))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.project_id.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    //AppSessionState.ViewOtherRecordAllowed = true;
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

        private bool Validation()
        {
            try
            {
                bool anyDuplicates = false;

                #region Master Fields Validation


                // Compulsory Fields Validation
                if (MasterEntity.project_name == null || MasterEntity.project_name == "" ||
                     MasterEntity.customer_id == null || MasterEntity.customer_id == "" ||
                     MasterEntity.project_manager == null || MasterEntity.project_manager == "" ||
                     MasterEntity.location_Id == null || MasterEntity.location_Id == "" ||
                     MasterEntity.start_date == null || MasterEntity.dead_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation: Compalsory Fields";
                    showMessageService.Text = String.Format("Fields Project Name, Customer, Project Manager, Plant, Schedule Start Date, Deadline Date are Compulsory", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                // Activate Validation Check
                if (MasterEntity.active == false)
                {
                    if (MasterEntity.t_status != null && MasterEntity.t_status != ""
                        && MasterEntity.t_status != "001" && MasterEntity.t_status != "002")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Cannot Inactivate the Project ";
                        showMessageService.Text = String.Format("You Cannot Inactivate the Project After you Have Started it..!!! ", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }


                // If Project is Stopped or Canceled Status Remark is Compulsory
                if (MasterEntity.t_status == "015" || MasterEntity.t_status == "006")
                {
                    if (MasterEntity.status_remark == null || MasterEntity.status_remark == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Status Remark ";
                        showMessageService.Text = String.Format("Please Enter Status Rermark for Status Stopped/Canceled..!!! ", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

                #endregion

                #region . Validation for Employee and Role .

                foreach (var o in EmployeeDetailsEntity)
                {
                    if (o.EmpId == null || o.EmpId == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Project Team";
                        showMessageService.Text = String.Format("Employee Id cannot be blank At Index {0}", EmployeeDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.Emp_Type == null || o.Emp_Type == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Project Team";
                        showMessageService.Text = String.Format("Employee Type cannot be blank At Index {0}", EmployeeDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.RoleCode == null || o.RoleCode == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Project Team";
                        showMessageService.Text = String.Format("Role cannot be blank for Employee {0} At Index {1}", o.empname, EmployeeDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                }
                #endregion

                #region . Duplicate Employee Check .

                // Checking Duplicate Employee
                anyDuplicates = EmployeeDetailsEntity.Select(x => new { x.EmpId }).Distinct().Count()
                                            < EmployeeDetailsEntity.Count();

                if (anyDuplicates == true)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Duplicate Employee Found, Please Delete Duplicate Employee First !! ");
                    showMessageService.ShowMessage();

                    return false;
                }

                #endregion


                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Items .
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemDetailsEntity)
                {
                    int flag = 0;
                    if (o.active == true)
                    {    // Item Duplication Validation
                        foreach (var p in ItemDetailsEntity)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku && p.active == true)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }

                    if (o.ItemCode != null && o.ItemCode != "")
                    {
                        if (o.quantity == null || o.quantity == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.location_Id == null || o.location_Id == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.store_code == null || o.store_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Storage Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("No ItemCode is Present at Index {0} \n Delete This Blank Row", ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

                #endregion

                #region . Duplicate Item Check .

                anyDuplicates = ItemDetailsEntity.Select(x => new { x.ItemCode, x.sku }).Distinct().Count()
                                                < ItemDetailsEntity.Count();

                if (anyDuplicates == true)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Duplicate Item Found, Please Delete Duplicate Item First !! ");
                    showMessageService.ShowMessage();

                    return false;

                }

                #endregion

                #region . Validation for Phases and Start End Date and Sequence No .

                if (PhaseDetailsEntity.Count > 0 && MasterEntity.use_tasks == true)
                {
                    foreach (var o in PhaseDetailsEntity)
                    {
                        if (o.phase_id == null || o.phase_id == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Phases";
                            showMessageService.Text = String.Format("Phase Id cannot be 0 or Blank At Index {0}", PhaseDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.sequence == null || o.sequence == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Phases";
                            showMessageService.Text = String.Format("Sequence No Cannot be Blank for Phase {0} At Index {1}", o.sequence, PhaseDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.start_date == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Phases";
                            showMessageService.Text = String.Format("Schedule Start Date Cannot be Blank for Phase {0} At Index {1}", o.phasenm, PhaseDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.dead_date == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Phases";
                            showMessageService.Text = String.Format("Deadline Date Cannot be Blank for Phase {0} At Index {1}", o.phasenm, PhaseDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }


                    // Sequence No Validation

                    int PhasesCount = PhaseDetailsEntity.Where(x => x.active == true).Count();  // Count of All Active Phases
                    int seqmax = PhaseDetailsEntity.Where(x => x.active == true).Max(x => x.sequence); // Getting Max Sequence No in the Collection when active is true

                    if (PhasesCount != seqmax)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation: Project Phases";
                        showMessageService.Text = String.Format("Please Give Proper Sequence No to All The Phases. \n For Example : If there are 5 active phases in project. Sequence No for 5 phases should be 1,2,3,4,5", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }


                    // Validating Duplicate Phase Number
                    anyDuplicates = PhaseDetailsEntity.Where(x => x.active == true).Select(x => new { x.phase_id }).Distinct().Count()
                                                < PhaseDetailsEntity.Count();

                    if (anyDuplicates == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.OkCancel;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Duplicate Phase Found, Please Delete Duplicate Phase First !! ");
                        showMessageService.ShowMessage();

                        return false;
                    }


                }
                else if (MasterEntity.use_tasks == false && PhaseDetailsEntity.Count > 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation: Project Phases";
                    showMessageService.Text = String.Format("You Have Chosen Not To use Tasks But You Have Added some phases in project phase Tab \n Please Click on Enable Task and Inactivate Those Phase and then Click On Enable Task Again To Disable using Task and Phases", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                #endregion

                #region . Validation for Task Creation DataGrid .

                if (TaskDetailsEntity.Count > 0 && MasterEntity.use_tasks == true)
                {
                    foreach (var o in TaskDetailsEntity)
                    {
                        if (o.title == null || o.title == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Task Title Cannot be Blank At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.phase_id == null || o.phase_id == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Phase Id cannot be 0 or Blank At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.EmpId == null || o.EmpId == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Assign To Task cannot be Blank At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }


                        if (o.sequence == null || o.sequence == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Sequence No Cannot be Blank or 0 At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.plan_hours == null || o.plan_hours == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Planned Hours Cannot be Blank or 0 At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.start_date == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Schedule Start Date Cannot be Blank At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.dead_date == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation: Project Task Creation";
                            showMessageService.Text = String.Format("Deadline Date Cannot be Blank At Index {0}", TaskDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }
                }
                #endregion

                #region . Duplicate Approval CheckList Point Check .

                //anyDuplicates = FinalApprovalCheckListEntity.Where(x => x.active == true).Select(x => new { x.point_id }).Distinct().Count()
                //                                < FinalApprovalCheckListEntity.Count();

                //if (anyDuplicates == true)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.OkCancel;
                //    showMessageService.Caption = "Project Final Approval CheckList";
                //    showMessageService.Text = String.Format("Duplicate Check List Point Found, Please Delete Duplicate Point First !! ");
                //    showMessageService.ShowMessage();

                //    return false;

                //}

                #endregion

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
                if (MasterEntity.XmlDataDocument_PRO_T001_A != null)
                {
                    MC.ProjectPhaseList = (ObservableCollection<PRO_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T001_A, MC.ProjectPhaseList);
                    PhaseDetailsEntity.Clear();
                    PhaseDetailsEntity = MC.ProjectPhaseList;
                }
                else
                {
                    MC.ProjectPhaseList = new ObservableCollection<PRO_T001_A>();
                }

                if (MasterEntity.XmlDataDocument_PRO_T001_B != null)
                {
                    MC.ProjectEmployeeList = (ObservableCollection<PRO_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T001_B, MC.ProjectEmployeeList);
                    EmployeeDetailsEntity.Clear();
                    EmployeeDetailsEntity = MC.ProjectEmployeeList;
                }
                else
                {
                    MC.ProjectEmployeeList = new ObservableCollection<PRO_T001_B>();
                }

                if (MasterEntity.XmlDataDocument_PRO_T001_C != null)
                {
                    MC.ProjectItemList = (ObservableCollection<PRO_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T001_C, MC.ProjectItemList);
                    ItemDetailsEntity.Clear();
                    ItemDetailsEntity = MC.ProjectItemList;
                }
                else
                {
                    MC.ProjectItemList = new ObservableCollection<PRO_T001_C>();
                }

                if (MasterEntity.XmlDataDocument_PRO_T001_D != null)
                {
                    MC.ProjectApprovalCheckList = (ObservableCollection<PRO_T001_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T001_D, MC.ProjectApprovalCheckList);
                    FinalApprovalCheckListEntity.Clear();
                    FinalApprovalCheckListEntity = MC.ProjectApprovalCheckList;
                }
                else
                {
                    MC.ProjectApprovalCheckList = new ObservableCollection<PRO_T001_D>();
                }

                if (MasterEntity.XmlDataDocument_PRO_T002 != null)
                {
                    MC.ProjectTaskList = (ObservableCollection<PRO_T002>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PRO_T002, MC.ProjectTaskList);
                    TaskDetailsEntity.Clear();
                    TaskDetailsEntity = MC.ProjectTaskList;
                }
                else
                {
                    MC.ProjectTaskList = new ObservableCollection<PRO_T002>();
                }

                if (MasterEntity.XmlDataDocument_FlipGrid != null)
                {
                    MC.ProjectList = (List<PRO_T001_FLIP>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.ProjectList);
                    FlipGridData.Add(MC.ProjectList[0]);
                    _ProjectCollection.Refresh();
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

        protected override void OnSaveAction(InquiryActionResult<PRO_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    MasterEntity.XmlDataDocument_PRO_T001_A = objSer.ObjectToXML(PhaseDetailsEntity);
                    MasterEntity.XmlDataDocument_PRO_T001_B = objSer.ObjectToXML(EmployeeDetailsEntity);
                    MasterEntity.XmlDataDocument_PRO_T001_C = objSer.ObjectToXML(ItemDetailsEntity);
                    MasterEntity.XmlDataDocument_PRO_T001_D = objSer.ObjectToXML(FinalApprovalCheckListEntity);
                    MasterEntity.XmlDataDocument_PRO_T002 = objSer.ObjectToXML(TaskDetailsEntity);

                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PRO_T001>(MasterEntity, "Project", "PM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PRO_T001>(MasterEntity, "Project", "PM");
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

        protected override void OnCreateAction(InquiryActionResult<PRO_T001> result)
        {
            try
            {
                NewRecord = true;
                kickoff = false;
                MasterEntity = new PRO_T001();

                PhaseDetailsEntity = new ObservableCollection<PRO_T001_A>();
                EmployeeDetailsEntity = new ObservableCollection<PRO_T001_B>();
                ItemDetailsEntity = new ObservableCollection<PRO_T001_C>();
                TaskDetailsEntity = new ObservableCollection<PRO_T002>();

                ProjectCollection.Refresh();
                MasterEntity.ValidateAsync().Wait();
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
        protected override void OnRemoveAction(InquiryActionResult<PRO_T001> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text = String.Format("This record will delete forever '{0}'", this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.EndEdit();
                    string response = repository.Delete(MasterEntity.project_id, "Project", "PM");

                    MasterEntity = new PRO_T001();
                    EmployeeDetailsEntity = new ObservableCollection<PRO_T001_B>();
                    PhaseDetailsEntity = new ObservableCollection<PRO_T001_A>();
                    ItemDetailsEntity = new ObservableCollection<PRO_T001_C>();
                    TaskDetailsEntity = new ObservableCollection<PRO_T002>();

                    ProjectCollection.Refresh();
                    NewRecord = true;

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
        protected override void OnDiscardAction(InquiryActionResult<PRO_T001> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_T001> result)
        {
            CursorControl.SetBusyState();
           // EntityChangeEnable = false;
            try
            {
                string Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + "PJ" + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.project_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                
                MCtemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T001>(MCtemp, Request, "Project", "PM", "LoadDocumentByDocumentNumber", 0, "");

                object[] objDataSource = new object[8];
                string[] objDataSourceName = new string[8];
            


                objDataSource[0] = MCtemp.ProjectMasterList;
                objDataSource[1] = MCtemp.ProjectPhaseList;
                objDataSource[2] = MCtemp.ProjectEmployeeList;
                objDataSource[3] = MCtemp.ProjectItemList;
                objDataSource[4] = MCtemp.ProjectApprovalCheckList;
                objDataSource[5] = MCtemp.ProjectTaskList;

           


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[6] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[7] = Result;
               

                objDataSourceName[0] = "dsProjectMasterList";
                objDataSourceName[1] = "dsProjectPhaseList";
                objDataSourceName[2] = "dsProjectEmployeeList";
                objDataSourceName[3] = "dsProjectItemList";
                objDataSourceName[4] = "dsProjectApprovalCheckList";
                objDataSourceName[5] = "dsProjectTaskList";
                objDataSourceName[6] = "dsCompany";
                objDataSourceName[7] = "dsLocation";


                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\PM\\ProjectDetails.rdlc", getParametersList(), "");
               // EntityChangeEnable = true;
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
        protected override void OnRefreshCommand(InquiryActionResult<PRO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.project_id))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.project_id.Replace("/", "--"), DocumentList = MCtemp.AttachmentData, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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

        #region Filters

        #region filter Team Employee
        public bool FilterEmployeeTeam(object obj)
        {
            var data = obj as ADM_M024_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmployeeTeam))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmployeeTeam.ToLower()) ||
                        data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterStringEmployeeTeam.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringEmployeeTeam;
        public string filterStringEmployeeTeam
        {
            get { return _filterStringEmployeeTeam; }
            set
            {
                _filterStringEmployeeTeam = value;
                RaisePropertyChanged("filterStringEmployeeTeam");
                FilterStringEmployeeTeam();
            }
        }
        private void FilterStringEmployeeTeam()
        {
            if (_TeamCollection != null)
            {
                _TeamCollection.Refresh();
            }
        }
        #endregion

        #region filter phase
        public bool FilterPhase(object obj)
        {
            var data = obj as PRO_M003_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPhase))
                {
                    return (data.phase_id != null && data.phase_id.ToString().ToLower().Contains(_filterStringPhase.ToLower()) ||
                        data.phase_name != null && data.phase_name.ToString().ToLower().Contains(_filterStringPhase.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringPhase;
        public string FilterStringPhase
        {
            get { return _filterStringPhase; }
            set
            {
                _filterStringPhase = value;
                RaisePropertyChanged("FilterStringPhase");
                FilterPhase();
            }
        }
        private void FilterPhase()
        {
            if (_PhaseCollection != null)
            {
                _PhaseCollection.Refresh();
            }
        }
        #endregion

        #region filter Task
        public bool FilterTask(object obj)
        {
            var data = obj as PRO_T002_P_1;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTask))
                {
                    return (data.title != null && data.title.ToString().ToLower().Contains(_filterStringTask.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringTask;
        public string FilterStringTask
        {
            get { return _filterStringTask; }
            set
            {
                _filterStringTask = value;
                RaisePropertyChanged("FilterStringTask");
                FilterTask();
            }
        }
        private void FilterTask()
        {
            if (_TaskCollection != null)
            {
                _TaskCollection.Refresh();
            }
        }
        #endregion

        #region filter Item
        public bool FilterItem(object obj)
        {
            var data = obj as ADM_M022_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringItem;
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterItem();
            }
        }
        private void FilterItem()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        #endregion

        #region filter Final Approval CheckList
        public bool FilterCheckList(object obj)
        {
            var data = obj as PRO_M005_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCheckList))
                {
                    return (data.point_id != null && data.point_id.ToString().ToLower().Contains(_filterStringCheckList.ToLower()) ||
                        data.point_description != null && data.point_description.ToString().ToLower().Contains(_filterStringCheckList.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringCheckList;
        public string FilterStringCheckList
        {
            get { return _filterStringCheckList; }
            set
            {
                _filterStringCheckList = value;
                RaisePropertyChanged("FilterStringCheckList");
                FilterCheckList();
            }
        }
        private void FilterCheckList()
        {
            if (_FinalApprovalCheckListCollection != null)
            {
                _FinalApprovalCheckListCollection.Refresh();
            }
        }
        #endregion

        #region Filter Project
        public bool FilterProject(object obj)
        {
            var data = obj as PRO_T001_FLIP;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProject))
                {
                    return (data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                            data.project_id != null && data.project_id.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                            data.projectmanagernm != null && data.projectmanagernm.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                            data.customernm != null && data.customernm.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                            data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                            data.start_date != null && data.start_date.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                                data.dead_date != null && data.dead_date.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                                data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                                data.planned_hours != null && data.planned_hours.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                                data.hours_spent != null && data.hours_spent.ToString().ToLower().Contains(_filterStringProject.ToLower()) ||
                                data.progress_rate != null && data.progress_rate.ToString().ToLower().Contains(_filterStringProject.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringProject;
        public string filterStringProject
        {
            get { return _filterStringProject; }
            set
            {
                _filterStringProject = value;
                RaisePropertyChanged("filterStringProject");
                FilterStringProject();
            }
        }
        private void FilterStringProject()
        {
            if (_ProjectCollection != null)
            {
                _ProjectCollection.Refresh();
            }
        }


        #endregion
        #region filter Sub Categary
        public bool FilterSubCategory(object obj)
        {
            var data = obj as PRO_M001_A_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCategory))
                {
                    return (data.sub_cat_code != null && data.sub_cat_code.ToString().ToLower().Contains(_filterStringSubCategory.ToLower()) ||
                           (data.sub_cat != null && data.sub_cat.ToString().ToLower().Contains(_filterStringSubCategory.ToLower())));
                }
                return true;
            }
            return false;
        }

        private string _filterStringSubCategory;
        public string FilterStringSubCategory
        {
            get { return _filterStringSubCategory; }
            set
            {
                _filterStringSubCategory = value;
                RaisePropertyChanged("FilterStringTask");
                FilterSubCategory();
            }
        }
        private void FilterSubCategory()
        {
            if (_SubCategoryCollection != null)
            {
                _SubCategoryCollection.Refresh();
            }
        }
        #endregion
        #endregion
    }
}
