using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.Production;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_M0004_VM : WorkspaceViewModel<QMS_M030>
    {
        bool NewRecord = true;

        WebServiceRepository<QMS_M030> repository = new WebServiceRepository<QMS_M030>();
        WebServiceRepository<MultipleContext_QMS_M030> repository_MC = new WebServiceRepository<MultipleContext_QMS_M030>();
        WebServiceRepository<MultipleContext_QMS_M030> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M030>();
        WebServiceRepository<MultipleContext_QMS_M030> repository_MCTemp1 = new WebServiceRepository<MultipleContext_QMS_M030>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_M0004_VM));
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
                    if (SourceName == "insp_char")
                    { ASDefault = ASInspChar; }
                    else if (SourceName == "insp_method")
                    { ASDefault = ASInspMethod; }
                    else if (SourceName == "samp_pro_char")
                    { ASDefault = ASSampleProcedure; }
                    else if (SourceName == "sample_uom")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "inspector_qualification")
                    { ASDefault = ASQualification; }

                    if (SourceName == "wc_code")
                    {
                        if (SEO_QMS_M030_B != null && MC.WorkCenter.Count > 0)
                        {
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).wc_code ?? "");
                            TheFilter = (o, prefix) => (((PPC_M001_P)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_P)o).machinedesc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASWWorkCenter = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenter.Where(x => x.location_Id == SEO_QMS_M030_B.location_Id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                            ASWWorkCenter.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        ASDefault1 = ASWWorkCenter;
                    }
                    else if (SourceName == "control_key")
                    { ASDefault1 = ASControlKey; }
                    else if (SourceName == "unit_code")
                    { ASDefault1 = ASUnit1; }
                    else if (SourceName == "op_code")
                    { ASDefault1 = ASOperation; }

                    if (SourceName == "ItemCode")
                    { ASDefault2 = ASItem1; }
                    else if (SourceName == "bom_no")
                    { ASDefault2 = ASBOM; }
                    else if (SourceName == "location_Id")
                    { ASDefault2 = ASPlant; }

                    if (SourceName == "para_type")
                    { ASDefault3 = ASParameterType; }
                    else if (SourceName == "gc_or_ss")
                    { ASDefault3 = ASProfile; }
                    else if (SourceName == "inspector")
                    { ASDefault2 = ASEmployees; }


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

        private AutoSuggestTextViewModel<dynamic> _ASDefault1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault1
        {
            get { return _ASDefault1; }
            set
            {
                if (_ASDefault1 != value)
                {
                    _ASDefault1 = value; RaisePropertyChanged("ASDefault1");
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

        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItem1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem1
        {
            get { return _ASItem1; }
            set
            {
                if (_ASItem1 != value)
                {
                    _ASItem1 = value; RaisePropertyChanged("ASItem1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInspMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspMethod
        {
            get { return _ASInspMethod; }
            set
            {
                if (_ASInspMethod != value)
                {
                    _ASInspMethod = value; RaisePropertyChanged("ASInspMethod");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSampleProcedure { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSampleProcedure
        {
            get { return _ASSampleProcedure; }
            set
            {
                if (_ASSampleProcedure != value)
                {
                    _ASSampleProcedure = value; RaisePropertyChanged("ASSampleProcedure");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASQualification { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQualification
        {
            get { return _ASQualification; }
            set
            {
                if (_ASQualification != value)
                {
                    _ASQualification = value; RaisePropertyChanged("ASQualification");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWWorkCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWWorkCenter
        {
            get { return _ASWWorkCenter; }
            set
            {
                if (_ASWWorkCenter != value)
                {
                    _ASWWorkCenter = value; RaisePropertyChanged("ASWWorkCenter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBOM
        {
            get { return _ASBOM; }
            set
            {
                if (_ASBOM != value)
                {
                    _ASBOM = value; RaisePropertyChanged("ASBOM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInspChar { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspChar
        {
            get { return _ASInspChar; }
            set
            {
                if (_ASInspChar != value)
                {
                    _ASInspChar = value; RaisePropertyChanged("ASInspChar");
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
        private AutoSuggestTextViewModel<dynamic> _ASPlant_C { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant_C
        {
            get { return _ASPlant_C; }
            set
            {
                if (_ASPlant_C != value)
                {
                    _ASPlant_C = value; RaisePropertyChanged("ASPlant_C");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit1
        {
            get { return _ASUnit1; }
            set
            {
                if (_ASUnit1 != value)
                {
                    _ASUnit1 = value; RaisePropertyChanged("ASUnit1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUsage { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUsage
        {
            get { return _ASUsage; }
            set
            {
                if (_ASUsage != value)
                {
                    _ASUsage = value; RaisePropertyChanged("ASUsage");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASOperation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOperation
        {
            get { return _ASOperation; }
            set
            {
                if (_ASOperation != value)
                {
                    _ASOperation = value; RaisePropertyChanged("ASOperation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASControlKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASControlKey
        {
            get { return _ASControlKey; }
            set
            {
                if (_ASControlKey != value)
                {
                    _ASControlKey = value; RaisePropertyChanged("ASControlKey");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParameterType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterType
        {
            get { return _ASParameterType; }
            set
            {
                if (_ASParameterType != value)
                {
                    _ASParameterType = value; RaisePropertyChanged("ASParameterType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASProfile { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProfile
        {
            get { return _ASProfile; }
            set
            {
                if (_ASProfile != value)
                {
                    _ASProfile = value; RaisePropertyChanged("ASProfile");
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
        private AutoSuggestTextViewModel<dynamic> _ASApprover { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASApprover
        {
            get { return _ASApprover; }
            set
            {
                if (_ASApprover != value)
                {
                    _ASApprover = value; RaisePropertyChanged("ASApprover");
                }
            }
        }
        #endregion

        #region Relay Command Decleration

        public RelayCommand<object> cmdSelectionChanged_QMS_M030_A { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_QMS_M030_B { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_QMS_M030_C { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_QMS_M030_D { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> AssignmentEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> InspCharEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> OperationEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> SelectedSetEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> CmdInspChar { get; private set; }
        public RelayCommand<object> CmdInspCharType { get; private set; }
        public RelayCommand<object> CmdInspMethod { get; private set; }
        public RelayCommand<object> CmdSampleProcedure { get; private set; }
        public RelayCommand<object> CmdSampleUOM { get; private set; }
        public RelayCommand<object> CmdInspectorQualification { get; private set; }
        public RelayCommand<object> CmdWorkCenter { get; private set; }
        public RelayCommand<object> CmdControlKey { get; private set; }
        public RelayCommand<object> CmdOperationUnit { get; private set; }
        public RelayCommand<object> CmdItem { get; private set; }
        public RelayCommand<object> CmdBomNo { get; private set; }
        public RelayCommand<object> CmdPlant { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocNo { get; private set; }
        public RelayCommand<object> CmdItemCode { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdCheckBoxChange { get; private set; }
        public RelayCommand<object> CmdProfile { get; private set; }
        public RelayCommand<object> CmdParaType { get; private set; }
        public RelayCommand<object> CmdCharProfile { get; private set; }

        #endregion

        #region Variable Decleration
        public string task_list_type_vm { get; set; }
        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool EntityChangeEnable = true;
        private QMS_M030 _MasterEntity;
        public QMS_M030 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    //value.BeginEdit();
                }
            }
        }
        private bool _Copy;
        public bool Copy
        {
            get { return _Copy; }
            set
            {
                if (_Copy != value)
                {
                    _Copy = value; RaisePropertyChanged("Copy");
                }
            }
        }
        private ObservableCollection<QMS_M030_A> _AssignmentEntity;
        public ObservableCollection<QMS_M030_A> AssignmentEntity
        {
            get { return _AssignmentEntity; }
            set
            {
                if (_AssignmentEntity != value)
                {
                    _AssignmentEntity = value;
                    RaisePropertyChanged("AssignmentEntity");
                }
            }
        }

        private ObservableCollection<QMS_M030_B> _OperationEntity;
        public ObservableCollection<QMS_M030_B> OperationEntity
        {
            get { return _OperationEntity; }
            set
            {
                if (_OperationEntity != value)
                {
                    _OperationEntity = value;
                    OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
                    RaisePropertyChanged("OperationEntity");
                }
            }
        }

        private ObservableCollection<QMS_M030_C> _InspCharEntity;
        public ObservableCollection<QMS_M030_C> InspCharEntity
        {
            get { return _InspCharEntity; }
            set
            {
                if (_InspCharEntity != value)
                {
                    _InspCharEntity = value;
                    RaisePropertyChanged("InspCharEntity");
                }
            }
        }
        private QMS_M030_A _SEO_QMS_M030_A;
        public QMS_M030_A SEO_QMS_M030_A
        {
            get
            {
                return _SEO_QMS_M030_A;
            }
            set
            {
                if (_SEO_QMS_M030_A != value)
                {
                    _SEO_QMS_M030_A = value;
                    RaisePropertyChanged("SEO_QMS_M030_A");
                }
            }
        }
        private QMS_M030_B _SEO_QMS_M030_B;
        public QMS_M030_B SEO_QMS_M030_B
        {
            get
            {
                return _SEO_QMS_M030_B;
            }
            set
            {
                if (_SEO_QMS_M030_B != value)
                {
                    _SEO_QMS_M030_B = value;
                    RaisePropertyChanged("SEO_QMS_M030_B");
                    FilterInspCharDataGrid();
                    FilterSelectedSetDataGrid();
                    FilterItemAssignmentDataGrid();
                }
            }
        }
        private QMS_M030_C _SEO_QMS_M030_C;
        public QMS_M030_C SEO_QMS_M030_C
        {
            get
            {
                return _SEO_QMS_M030_C;
            }
            set
            {
                if (_SEO_QMS_M030_C != value)
                {
                    _SEO_QMS_M030_C = value;
                    RaisePropertyChanged("SEO_QMS_M030_C");
                    FilterSelectedSetDataGrid();
                    FilterItemAssignmentDataGrid();
                }
            }
        }
        private QMS_M030_D _SEO_QMS_M030_D;
        public QMS_M030_D SEO_QMS_M030_D
        {
            get
            {
                return _SEO_QMS_M030_D;
            }
            set
            {
                if (_SEO_QMS_M030_D != value)
                {
                    _SEO_QMS_M030_D = value;
                    RaisePropertyChanged("SEO_QMS_M030_D");
                }
            }
        }
        private ObservableCollection<QMS_M030_D> _SelectedSetEntity;
        public ObservableCollection<QMS_M030_D> SelectedSetEntity
        {
            get { return _SelectedSetEntity; }
            set
            {
                if (_SelectedSetEntity != value)
                {
                    _SelectedSetEntity = value;
                    RaisePropertyChanged("SelectedSetEntity");
                }
            }
        }

        private int _dgSelectedIndexAssign;
        public int dgSelectedIndexAssign
        {
            get { return _dgSelectedIndexAssign; }
            set
            {
                if (_dgSelectedIndexAssign != value)
                {
                    _dgSelectedIndexAssign = value;
                    RaisePropertyChanged("dgSelectedIndexAssign");
                }
            }
        }

        private int _dgSelectedIndexOperation;
        public int dgSelectedIndexOperation
        {
            get { return _dgSelectedIndexOperation; }
            set
            {
                if (_dgSelectedIndexOperation != value)
                {
                    _dgSelectedIndexOperation = value;
                    RaisePropertyChanged("dgSelectedIndexOperation");
                    FilterInspCharDataGrid();
                    FilterItemAssignmentDataGrid();
                }
            }
        }

        private int _dgSelectedIndexInspChar;
        public int dgSelectedIndexInspChar
        {
            get { return _dgSelectedIndexInspChar; }
            set
            {
                if (_dgSelectedIndexInspChar != value)
                {
                    _dgSelectedIndexInspChar = value;
                    RaisePropertyChanged("dgSelectedIndexInspChar");
                }
            }
        }

        private int _dgSelectedIndexSet;
        public int dgSelectedIndexSet
        {
            get { return _dgSelectedIndexSet; }
            set
            {
                if (_dgSelectedIndexSet != value)
                {
                    _dgSelectedIndexSet = value;
                    RaisePropertyChanged("dgSelectedIndexSet");
                }
            }
        }

        private MultipleContext_QMS_M030 _MC;
        public MultipleContext_QMS_M030 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M030 _MCTemp;
        public MultipleContext_QMS_M030 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_M030 _MCTemp1;
        public MultipleContext_QMS_M030 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private List<QMS_M030_Flip> _FlipGridData;
        public List<QMS_M030_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _ItemCodeCollection;
        public ICollectionView ItemCodeCollection
        {
            get { return _ItemCodeCollection; }
            set { _ItemCodeCollection = value; RaisePropertyChanged("ItemCodeCollection"); }
        }

        private ICollectionView _InspCharCollection;
        public ICollectionView InspCharCollection
        {
            get { return _InspCharCollection; }
            set { _InspCharCollection = value; RaisePropertyChanged("InspCharCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }

        public List<ADM_M003> _PlantList = new List<ADM_M003>();
        private List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
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

        private ICollectionView _InspCharDataGridCollection;
        public ICollectionView InspCharDataGridCollection
        {
            get { return _InspCharDataGridCollection; }
            set
            {
                _InspCharDataGridCollection = value;
                RaisePropertyChanged("InspCharDataGridCollection");
            }
        }

        private ICollectionView _SelectedDataGridCollection;
        public ICollectionView SelectedDataGridCollection
        {
            get { return _SelectedDataGridCollection; }
            set
            {
                _SelectedDataGridCollection = value;
                RaisePropertyChanged("SelectedDataGridCollection");
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

        #region Constructor
        public PPC_M0004_VM(string ts_code, string doc_cat, string task_list_type) : base()
        {
            this.ts_code_vm = ts_code;
            this.task_list_type_vm = task_list_type;
            this.doc_cat_vm = doc_cat;
            MasterEntity = new QMS_M030();
            InspCharEntity = new ObservableCollection<QMS_M030_C>();
            OperationEntity = new ObservableCollection<QMS_M030_B>();
            AssignmentEntity = new ObservableCollection<QMS_M030_A>();
            SelectedSetEntity = new ObservableCollection<QMS_M030_D>();
            MC = new MultipleContext_QMS_M030();
            MCTemp = new MultipleContext_QMS_M030();
            MCTemp1 = new MultipleContext_QMS_M030();
            QMS_M030_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            LoadInitialData();
            DefaultValues();
        }
        public PPC_M0004_VM(string ts_code, string doc_cat, string task_list_type, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.task_list_type_vm = task_list_type;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;

            MasterEntity = new QMS_M030();
            InspCharEntity = new ObservableCollection<QMS_M030_C>();
            OperationEntity = new ObservableCollection<QMS_M030_B>();
            AssignmentEntity = new ObservableCollection<QMS_M030_A>();
            SelectedSetEntity = new ObservableCollection<QMS_M030_D>();
            MC = new MultipleContext_QMS_M030();
            MCTemp = new MultipleContext_QMS_M030();
            MCTemp1 = new MultipleContext_QMS_M030();
            QMS_M030_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region User Define Methods

        #region InspCharEntity Methods
        private void LoadInitialData()
        {
            try
            {
                #region Relay Command Initalization
                cmdSelectionChanged_QMS_M030_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_QMS_M030_A(items); });
                cmdSelectionChanged_QMS_M030_B = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_QMS_M030_B(items); });
                cmdSelectionChanged_QMS_M030_C = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_QMS_M030_C(items); });
                cmdSelectionChanged_QMS_M030_D = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_QMS_M030_D(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                AssignmentEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteAssignmentEntityRow(cmdPara); });
                InspCharEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteInspCharEntityRow(cmdPara); });
                OperationEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteOperationEntityRow(cmdPara); });
                SelectedSetEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteSelectedSetEntityRow(cmdPara); });
                CmdInspChar = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInspectionCharacteristics(cmdPara, true, true, true); });
                CmdInspMethod = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInspectionMethod(cmdPara, false, true, true); });
                CmdSampleProcedure = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSampleProcedure(cmdPara, false, true, true); });
                CmdSampleUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSampleUOM(cmdPara, false, true, true); });
                CmdInspectorQualification = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInspQualification(cmdPara, false, true, true); });
                CmdWorkCenter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWorkCenter(cmdPara, false, true, true); });
                CmdControlKey = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertControlKey(cmdPara, false, true, true); });
                CmdOperationUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOperationUOM(cmdPara, false, true, true); });
                CmdItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAssignmentEntityItem(cmdPara, true, true, true); });
                CmdBomNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBOM(cmdPara, false, true, true); });
                CmdPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlant(cmdPara, false, true, true); });
                CmdLoadDocumentByDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdItemCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMasterItem(cmdPara); });
                CmdCheckBoxChange = new GalaSoft.MvvmLight.Command.RelayCommand(() => { CheckBoxSelectionChange(); });
                CmdProfile = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParaProfileOrGroup(cmdPara, false, true, true); });
                CmdParaType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameterType(cmdPara, true, true, true); });
                CmdCharProfile = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCharProfile(cmdPara, true, true, true); });
                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + task_list_type_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M030>(MC, Request, "InspectionPlan", "QMS", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipData;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                ItemCodeCollection = CollectionViewSource.GetDefaultView(MC.ItemMaster);
                ItemCodeCollection.Filter = new Predicate<object>(FilterItemCollection);

                InspCharCollection = CollectionViewSource.GetDefaultView(MC.MICMaster);
                InspCharCollection.Filter = new Predicate<object>(FilterInspCharCollection);

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.ParaTypeMaster);
                ParameterCollection.Filter = new Predicate<object>(FilterParameterCollection);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemMaster, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem1 = new AutoSuggestTextViewModel<dynamic>(MC.ItemMaster, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItem1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.ItemMaster, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_G_P)x).insp_method ?? "");
                TheFilter = (o, prefix) => (((QMS_M030_G_P)o).insp_method ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M030_G_P)o).method_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspMethod = new AutoSuggestTextViewModel<dynamic>(MC.InspMethod, TheFilter, SuggestedValue, "insp_method", "insp_method", true);
                ASInspMethod.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M034_P)x).sp_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M034_P)o).sp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M034_P)o).sp_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSampleProcedure = new AutoSuggestTextViewModel<dynamic>(MC.SampleProcedure, TheFilter, SuggestedValue, "samp_pro_char", "sp_code", true);
                ASSampleProcedure.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "sample_uom", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUnit1 = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit1.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M022_P)x).qualification ?? "");
                TheFilter = (o, prefix) => (((QMS_M022_P)o).qualification ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M022_P)o).description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASQualification = new AutoSuggestTextViewModel<dynamic>(MC.QualiMaster, TheFilter, SuggestedValue, "inspector_qualification", "qualification", true);
                ASQualification.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).wc_code ?? "");
                //TheFilter = (o, prefix) => (((PPC_M001_P)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_P)o).machinedesc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                //ASWWorkCenter = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenter, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                //ASWWorkCenter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).machinecode ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_P)o).machinecode ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenter, TheFilter, SuggestedValue, "inst_code", "machinecode", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no ?? "");
                TheFilter = (o, prefix) => (((ENG_T001_P)o).doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASBOM = new AutoSuggestTextViewModel<dynamic>(MC.BOMData, TheFilter, SuggestedValue, "bom_no", "doc_no", true);
                ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_I_P)x).insp_char ?? "");
                TheFilter = (o, prefix) => (((QMS_M030_I_P)o).insp_char ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M030_I_P)o).char_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspChar = new AutoSuggestTextViewModel<dynamic>(MC.MICMaster, TheFilter, SuggestedValue, "insp_char", "insp_char", true);
                ASInspChar.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_I_P)x).insp_char);
                TheFilter = (o, prefix) => (((QMS_M030_I_P)o).insp_char ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M030_I_P)o).char_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.MICMaster, TheFilter, SuggestedValue, "insp_char", "insp_char", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                PlantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Plant = (from o in PlantList where o.comp_code == AppSessionState.OBJ_COMPANY.comp_code select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(Plant, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                var Plant_C = (from o in PlantList where o.comp_code == AppSessionState.OBJ_COMPANY.comp_code select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant_C = new AutoSuggestTextViewModel<dynamic>(Plant_C, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant_C.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M048)x).task_list_use ?? "");
                TheFilter = (o, prefix) => (((SYS_M048)o).task_list_use ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M048)o).use_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUsage = new AutoSuggestTextViewModel<dynamic>(MC.UsageMaster, TheFilter, SuggestedValue, "task_list_use", true);
                ASUsage.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M051)x).control_key ?? "");
                TheFilter = (o, prefix) => (((SYS_M051)o).control_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M051)o).control_key_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASControlKey = new AutoSuggestTextViewModel<dynamic>(MC.ControlKeyMaster, TheFilter, SuggestedValue, "control_key", "control_key", true);
                ASControlKey.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M032_P)x).para_type ?? "");
                TheFilter = (o, prefix) => (((QMS_M032_P)o).para_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M032_P)o).cat_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParameterType = new AutoSuggestTextViewModel<dynamic>(MC.ParaTypeMaster, TheFilter, SuggestedValue, "para_type", "para_type", true);
                ASParameterType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M032_P)x).para_type ?? "");
                TheFilter = (o, prefix) => (((QMS_M032_P)o).para_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M032_P)o).cat_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MC.ParaTypeMaster, TheFilter, SuggestedValue, "para_type", "para_type", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;

                var SelectedSetOrGroupCode = (from o in MC.GroupSetMaster where o.Seperator == "SelectedSet" select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Group_Set)x).para_prof_code ?? "");
                TheFilter = (o, prefix) => (((Group_Set)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Group_Set)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASProfile = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                ASProfile.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEmployees = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "inspector", "EmpId", true);
                ASEmployees.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASEmployees.AutoSuggestVM.IsFreeTextAllowed = false;

                List<ADM_M024_P> ApprovarList = MC.EmployeeList.Where(x => x.EmpId != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASApprover = new AutoSuggestTextViewModel<dynamic>(ApprovarList, TheFilter, SuggestedValue, "approve_by", "EmpId", true);
                ASApprover.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASApprover.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M002)x).op_code);
                TheFilter = (o, prefix) => (((PPC_M002)o).op_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M002)o).op_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOperation = new AutoSuggestTextViewModel<dynamic>(MC.OperationList, TheFilter, SuggestedValue, "op_code", "op_code", true);
                ASOperation.AutoSuggestVM.IsEmptyValueAllowed = true; ASOperation.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion
                DefaultValues();
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (MasterEntity.valid_from == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Requird";
                showMessageService.Text = String.Format("Valid From Date is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (Copy == true)
            {
                NewRecord = true;

            }
            //if (MasterEntity.lot_size_from == null || MasterEntity.lot_size_from.ToString() == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Required";
            //    showMessageService.Text = String.Format("Lot Size From is Required");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            //if (MasterEntity.lot_size_to == null || MasterEntity.lot_size_to.ToString() == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Required";
            //    showMessageService.Text = String.Format("Lot Size To is Required");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Item Code is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (OperationEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Operation Code In Operation Tab");
                showMessageService.ShowMessage();
                return false;
            }
            //if (InspCharEntity.Count < 1) use only when inspection plan task_list_Type is active
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Insp.Characteristic");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //if (AssignmentEntity.Count < 1) use only when inspection plan task_list_Type is active
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Item Code is Required In Assignment Tab");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            return true;
        }
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client; ;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.task_list_type = this.task_list_type_vm;
            MasterEntity.plan_date = System.DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.t_status = "001";
            MasterEntity.valid_from = System.DateTime.Now;

        }
        private void InsertMasterItem(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.ItemMaster.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_QMS_M030_A != null)
            {
                AssignmentEntity.Clear();
                AssignmentEntity = (ObservableCollection<QMS_M030_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_A, MC.AssignmentEntity);
            }
            else
            {
                MC.AssignmentEntity = new ObservableCollection<QMS_M030_A>();
            }

            if (MasterEntity.XmlDataDocument_QMS_M030_B != null)
            {
                OperationEntity.Clear();
                OperationEntity = (ObservableCollection<QMS_M030_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_B, MC.OperationEntity);
            }
            else
            {
                MC.OperationEntity = new ObservableCollection<QMS_M030_B>();
            }

            if (MasterEntity.XmlDataDocument_QMS_M030_C != null)
            {
                InspCharEntity.Clear();
                InspCharEntity = (ObservableCollection<QMS_M030_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_C, MC.InspCharEntity);
            }
            else
            {
                MC.InspCharEntity = new ObservableCollection<QMS_M030_C>();
            }

            if (MasterEntity.XmlDataDocument_QMS_M030_D != null)
            {
                SelectedSetEntity.Clear();
                SelectedSetEntity = (ObservableCollection<QMS_M030_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_D, MC.SelectedSetEntity);
            }
            else
            {
                MC.SelectedSetEntity = new ObservableCollection<QMS_M030_D>();
            }


            if (MasterEntity.XmlDataDocument_QMS_M030_Flip != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipData = (List<QMS_M030_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_Flip, MC.BackFlipData);
                FlipGridData.Add(MC.BackFlipData[0]);
                DataGridCollection.Refresh();
                DataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
            }
            MasterEntity.ts_code = ts_code_vm;
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
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionChanged_QMS_M030_A(object InputValue)
        {
            try
            {
                SEO_QMS_M030_A = (QMS_M030_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_QMS_M030_B(object InputValue)
        {
            try
            {
                SEO_QMS_M030_B = (QMS_M030_B)InputValue;
                FilterInspCharDataGrid();
                FilterSelectedSetDataGrid();
                FilterItemAssignmentDataGrid();
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_QMS_M030_C(object InputValue)
        {
            try
            {
                SEO_QMS_M030_C = (QMS_M030_C)InputValue;
                FilterSelectedSetDataGrid();
                FilterItemAssignmentDataGrid();
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_QMS_M030_D(object InputValue)
        {
            try
            {
                SEO_QMS_M030_D = (QMS_M030_D)InputValue;
            }
            catch (Exception ex) { }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            EntityChangeEnable = false;
            string Request = "";
            QMS_M030_Flip ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<QMS_M030_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M030_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + ParameterEntityObject.plan_no;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_QMS_M030>(MCTemp, Request, "InspectionPlan", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity != null)
                {
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                        OperationEntity = MCTemp.OperationEntity;
                        AssignmentEntity = MCTemp.AssignmentEntity;
                        InspCharEntity = MCTemp.InspCharEntity;
                        SelectedSetEntity = MCTemp.SelectedSetEntity;
                    }
                }

            }
            SelectedTabControlIndex = 0;
            MasterEntity.ts_code = ts_code_vm;
            EntityChangeEnable = true;
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void DeleteInspCharEntityRow(object InputValue)
        {
            try
            {
                if (SEO_QMS_M030_C != null && (InspCharEntity[dgSelectedIndexInspChar].id == 0 || Copy == true))
                {
                    if (SelectedSetEntity.Count > 0)
                    {
                        var itemsToRemove = SelectedSetEntity.Where(x => x.operation_no == SEO_QMS_M030_C.operation_no && x.insp_char == SEO_QMS_M030_C.insp_char).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.operation_no == SEO_QMS_M030_C.operation_no && x.insp_char == SEO_QMS_M030_C.insp_char && x.gc_or_ss == item.gc_or_ss).Single());
                        }
                    }
                    if (InspCharEntity.Count > 0)
                    {
                        InspCharEntity.Remove(InspCharEntity.Where(x => x.operation_no == SEO_QMS_M030_C.operation_no && x.insp_char == SEO_QMS_M030_C.insp_char).Single());
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertInspectionCharacteristics(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M030_I_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MICMaster.Where(x => x.insp_char.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M030_I_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M030_I_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (OperationEntity.Count > 0)
                    {
                        if (dgSelectedIndexInspChar != -1)
                        {
                            var InputValueIfExists = InspCharEntity.Where(X => X.insp_char == POPUPEntityObject.insp_char).FirstOrDefault(); // Prefer Primary Key for this instruction.
                            int IndexOfExistValue = InspCharEntity.IndexOf(InspCharEntity.Where(X => X.insp_char == POPUPEntityObject.insp_char).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.                                                                    

                            List<QMS_M030_C> temp = new List<QMS_M030_C>();
                            temp = InspCharEntity.ToList();
                            foreach (var o in InspCharEntity)
                            {
                                if (o.operation_no != OperationEntity[dgSelectedIndexOperation].operation_no)
                                {
                                    temp.Remove(o);
                                }
                            }

                            if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && temp.Count == dgSelectedIndexInspChar)
                            {
                                InspCharEntity.Add(new QMS_M030_C()
                                {
                                    id = 0,
                                    insp_char_no = InspCharEntity.Count + 1,
                                    insp_char = POPUPEntityObject.insp_char,
                                    CharName = POPUPEntityObject.char_desc,
                                    operation_no = OperationEntity[dgSelectedIndexOperation].operation_no,
                                    insp_char_type = POPUPEntityObject.insp_char_type,
                                    lower_limit = POPUPEntityObject.lower_limit,
                                    upp_limit = POPUPEntityObject.upp_limit,
                                    insp_char_version_no = POPUPEntityObject.version_no,
                                    valid_from = POPUPEntityObject.from_date,
                                    insp_char_location = POPUPEntityObject.insp_char_location,
                                    way_char = POPUPEntityObject.way_char,
                                    inspector_qualification = POPUPEntityObject.inspector_qualification,
                                    t_status = "Draft",
                                    active = true,
                                    add_by = AppSessionState.UserID,
                                    editby = AppSessionState.UserID,
                                    edit_date = System.DateTime.Now,
                                    add_date = System.DateTime.Now,
                                    comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                    location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                    line_id_op = OperationEntity[dgSelectedIndexOperation].line_id,
                                    line_id = InspCharEntity.Count + 1
                                });
                            }
                            else if (dgSelectedIndexInspChar >= 0 && InspCharEntity.Count > dgSelectedIndexInspChar && SEO_QMS_M030_C != null) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                            {
                                foreach (var a in InspCharEntity)
                                {

                                    if (SEO_QMS_M030_C.operation_no == a.operation_no && a.id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                                    {
                                        a.insp_char = POPUPEntityObject.insp_char;
                                        a.CharName = POPUPEntityObject.char_desc;
                                        a.operation_no = OperationEntity[dgSelectedIndexOperation].operation_no;
                                        a.insp_char_type = POPUPEntityObject.insp_char_type;
                                        a.lower_limit = POPUPEntityObject.lower_limit;
                                        a.upp_limit = POPUPEntityObject.upp_limit;
                                        a.insp_char_version_no = POPUPEntityObject.version_no;
                                        a.valid_from = POPUPEntityObject.from_date;
                                        a.insp_char_location = POPUPEntityObject.insp_char_location;
                                        a.way_char = POPUPEntityObject.way_char;
                                        a.inspector_qualification = POPUPEntityObject.inspector_qualification;
                                        a.t_status = "Draft";
                                        a.active = true;
                                        a.add_by = AppSessionState.UserID;
                                        a.editby = AppSessionState.UserID;
                                        a.edit_date = System.DateTime.Now;
                                        a.add_date = System.DateTime.Now;
                                        a.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                        a.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                    }
                                    else if (SEO_QMS_M030_C.insp_char != POPUPEntityObject.insp_char)
                                    {
                                        SEO_QMS_M030_C.insp_char = null;
                                        SEO_QMS_M030_C.CharName = null;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("First Fill Operation Tab Details And Then Select Characteristics"); sms.ShowMessage();
                    }
                }
                #region Clear Empty Row
                QMS_M030_C newObj = new QMS_M030_C();
                for (int i = InspCharEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = InspCharEntity[i].ComparePropertiesTo(newObj);
                    if (InspCharEntity[i].ComparePropertiesTo(newObj) == true && InspCharEntity.Count > 1)
                    {
                        InspCharEntity.RemoveAt(i);
                        if (InspCharEntity.Count == 0)
                        {
                            InspCharEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertInspectionMethod(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M030_G_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.InspMethod.Where(x => x.insp_method.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M030_G_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M030_G_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && SEO_QMS_M030_C != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_C.insp_method = POPUPEntityObject.insp_method;
                    SEO_QMS_M030_C.MethodNm = POPUPEntityObject.method_desc;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSampleProcedure(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M034_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SampleProcedure.Where(x => x.sp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M034_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M034_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && SEO_QMS_M030_C != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_C.samp_pro_char = POPUPEntityObject.sp_code;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSampleUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.UnitMaster.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && SEO_QMS_M030_C != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_C.sample_uom = POPUPEntityObject.unit_code;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InsertInspQualification(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M022_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.QualiMaster.Where(x => x.qualification.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M022_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M022_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && SEO_QMS_M030_C != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_C.inspector_qualification = POPUPEntityObject.qualification;
                }
                #region Clear Empty Row
                QMS_M030_C newObj = new QMS_M030_C();
                for (int i = InspCharEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = InspCharEntity[i].ComparePropertiesTo(newObj);
                    if (InspCharEntity[i].ComparePropertiesTo(newObj) == true && InspCharEntity.Count > 1)
                    {
                        InspCharEntity.RemoveAt(i);
                        if (InspCharEntity.Count == 0)
                        {
                            InspCharEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertCharProfile(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                Group_Set POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string))
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.GroupSetMaster.Where(X => X.para_prof_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Group_Set>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Group_Set>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_C.gc_or_ss = POPUPEntityObject.para_prof_code;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion

        #region OperationEntity Methods
        private void DeleteOperationEntityRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (OperationEntity.Count > i && (OperationEntity[dgSelectedIndexOperation].id == 0 || Copy == true))
                {
                    if (InspCharEntity.Count > 0)
                    {
                        var itemsToRemove = InspCharEntity.Where(x => x.operation_no == SEO_QMS_M030_B.operation_no).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            InspCharEntity.Remove(InspCharEntity.Where(x => x.operation_no == SEO_QMS_M030_B.operation_no && x.insp_char == item.insp_char).Single());
                        }
                    }
                    if (SelectedSetEntity.Count > 0)
                    {
                        var itemsToRemove = SelectedSetEntity.Where(x => x.operation_no == SEO_QMS_M030_B.operation_no).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.operation_no == SEO_QMS_M030_B.operation_no && x.insp_char == item.insp_char && x.gc_or_ss == item.gc_or_ss).Single());
                        }
                    }
                    OperationEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void FilterItemAssignmentDataGrid()
        {
            try
            {
                if (AssignmentEntity != null && AssignmentEntity.Count > 0 && dgSelectedIndexOperation >= 0)
                {
                    InspCharDataGridCollection = CollectionViewSource.GetDefaultView(AssignmentEntity);
                    InspCharDataGridCollection.Filter = adv => ((QMS_M030_A)adv).line_id_op.Equals(OperationEntity[dgSelectedIndexOperation].line_id);
                    InspCharDataGridCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterInspCharDataGrid()
        {
            try
            {
                if (InspCharEntity != null && InspCharEntity.Count > 0 && dgSelectedIndexOperation >= 0)
                {
                    InspCharDataGridCollection = CollectionViewSource.GetDefaultView(InspCharEntity);
                    InspCharDataGridCollection.Filter = adv => ((QMS_M030_C)adv).operation_no.Equals(OperationEntity[dgSelectedIndexOperation].operation_no);
                    InspCharDataGridCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterSelectedSetDataGrid()
        {
            try
            {
                if (SelectedSetEntity != null && SelectedSetEntity.Count > 0 && SEO_QMS_M030_C != null)
                {
                    SelectedDataGridCollection = CollectionViewSource.GetDefaultView(SelectedSetEntity);
                    SelectedDataGridCollection.Filter = adv => ((QMS_M030_D)adv).operation_no.Equals(SEO_QMS_M030_C.operation_no) && ((QMS_M030_D)adv).insp_char.Equals(SEO_QMS_M030_C.insp_char);
                    SelectedDataGridCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertWorkCenter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PPC_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.WorkCenter.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = OperationEntity.Where(X => X.inst_code == POPUPEntityObject.machinecode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = OperationEntity.IndexOf(OperationEntity.Where(X => X.inst_code == POPUPEntityObject.machinecode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexOperation >= 0 && OperationEntity.Count > dgSelectedIndexOperation) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            OperationEntity[dgSelectedIndexOperation].inst_code = POPUPEntityObject.wc_code;
                        }
                        else if (OperationEntity[dgSelectedIndexOperation].inst_code != POPUPEntityObject.wc_code)
                        {
                            OperationEntity[dgSelectedIndexOperation].inst_code = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InsertControlKey(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M051 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ControlKeyMaster.Where(x => x.control_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M051>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M051>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = OperationEntity.Where(X => X.control_key == POPUPEntityObject.control_key).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = OperationEntity.IndexOf(OperationEntity.Where(X => X.control_key == POPUPEntityObject.control_key).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexOperation >= 0 && OperationEntity.Count > dgSelectedIndexOperation) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            OperationEntity[dgSelectedIndexOperation].control_key = POPUPEntityObject.control_key;
                        }
                        else if (OperationEntity[dgSelectedIndexOperation].control_key != POPUPEntityObject.control_key)
                        {
                            OperationEntity[dgSelectedIndexOperation].control_key = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOperationUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.UnitMaster.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = OperationEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = OperationEntity.IndexOf(OperationEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexOperation >= 0 && OperationEntity.Count > dgSelectedIndexOperation) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            OperationEntity[dgSelectedIndexOperation].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (OperationEntity[dgSelectedIndexOperation].unit_code != POPUPEntityObject.unit_code)
                        {
                            OperationEntity[dgSelectedIndexOperation].unit_code = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        #endregion

        #region AssignmentEntity Methods
        private void DeleteAssignmentEntityRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AssignmentEntity.Count > i && (AssignmentEntity[dgSelectedIndexAssign].id == 0 || NewRecord == true))
                {
                    AssignmentEntity.RemoveAt(i);

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertAssignmentEntityItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemMaster.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexAssign != -1)
                    {
                        var InputValueIfExists = AssignmentEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.line_id_op == SEO_QMS_M030_B.line_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = AssignmentEntity.IndexOf(AssignmentEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.line_id_op == SEO_QMS_M030_B.line_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (IndexOfExistValue == -1)
                        {
                            AssignmentEntity.Add(new QMS_M030_A()
                            {
                                id = 0,
                                ItemCode = POPUPEntityObject.ItemCode,
                                ItemName = POPUPEntityObject.ItemName,
                                comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                add_date = System.DateTime.Now,
                                edit_date = System.DateTime.Now,
                                t_status = "Draft",
                                active = true,
                                line_id_op = SEO_QMS_M030_B.line_id,
                                line_id = AssignmentEntity.Count + 1
                            });
                        }
                        else if (dgSelectedIndexAssign >= 0 && AssignmentEntity.Count > dgSelectedIndexAssign) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (AssignmentEntity[dgSelectedIndexAssign].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                AssignmentEntity[dgSelectedIndexAssign].ItemCode = POPUPEntityObject.ItemCode;
                                AssignmentEntity[dgSelectedIndexAssign].ItemName = POPUPEntityObject.ItemName;
                                AssignmentEntity[dgSelectedIndexAssign].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                AssignmentEntity[dgSelectedIndexAssign].location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                AssignmentEntity[dgSelectedIndexAssign].add_by = AppSessionState.UserID;
                                AssignmentEntity[dgSelectedIndexAssign].editby = AppSessionState.UserID;
                                AssignmentEntity[dgSelectedIndexAssign].add_date = System.DateTime.Now;
                                AssignmentEntity[dgSelectedIndexAssign].edit_date = System.DateTime.Now;
                                AssignmentEntity[dgSelectedIndexAssign].t_status = "Draft";
                                AssignmentEntity[dgSelectedIndexAssign].active = true;
                                AssignmentEntity[dgSelectedIndexAssign].line_id_op = SEO_QMS_M030_B.line_id;
                            }
                            else if (AssignmentEntity[dgSelectedIndexAssign].ItemCode != POPUPEntityObject.ItemCode)
                            {
                                AssignmentEntity[dgSelectedIndexAssign].ItemCode = null;
                                AssignmentEntity[dgSelectedIndexAssign].ItemName = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertBOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowMdify)
        {
            try
            {
                string Request = "";
                ENG_T001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BOMData.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = AssignmentEntity.Where(X => X.bom_no == POPUPEntityObject.doc_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = AssignmentEntity.IndexOf(AssignmentEntity.Where(X => X.bom_no == POPUPEntityObject.doc_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexAssign >= 0 && AssignmentEntity.Count > dgSelectedIndexAssign) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            AssignmentEntity[dgSelectedIndexAssign].bom_no = POPUPEntityObject.doc_no;
                        }
                        else if (AssignmentEntity[dgSelectedIndexAssign].bom_no != POPUPEntityObject.doc_no)
                        {
                            AssignmentEntity[dgSelectedIndexAssign].bom_no = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertPlant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = AssignmentEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = AssignmentEntity.IndexOf(AssignmentEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexAssign >= 0 && AssignmentEntity.Count > dgSelectedIndexAssign) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            AssignmentEntity[dgSelectedIndexAssign].location_Id = POPUPEntityObject.location_Id;
                        }
                        else if (AssignmentEntity[dgSelectedIndexAssign].location_Id != POPUPEntityObject.location_Id)
                        {
                            AssignmentEntity[dgSelectedIndexAssign].location_Id = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion

        #region SelectedSetEntity Methods
        private void DeleteSelectedSetEntityRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (SEO_QMS_M030_D != null)
                {
                    if (SelectedSetEntity.Count > i && (SEO_QMS_M030_D.id == 0 || Copy == true))
                    {
                        SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.operation_no == SEO_QMS_M030_D.operation_no && x.insp_char == SEO_QMS_M030_D.insp_char && x.gc_or_ss == SEO_QMS_M030_D.gc_or_ss).Single());
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CheckBoxSelectionChange()
        {
            try
            {
                if (SEO_QMS_M030_D.ind_gc_or_ss == true)
                {
                    var SelectedSetOrGroupCode = (from o in MC.GroupSetMaster where o.Seperator == "GroupCode" select o);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((Group_Set)x).para_prof_code ?? "");
                    TheFilter = (o, prefix) => (((Group_Set)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Group_Set)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASProfile = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                    ASProfile.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
                else if (SEO_QMS_M030_D.ind_gc_or_ss == false || SEO_QMS_M030_D.ind_gc_or_ss == null)
                {
                    var SelectedSetOrGroupCode = (from o in MC.GroupSetMaster where o.Seperator == "SelectedSet" select o);
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((Group_Set)x).para_prof_code ?? "");
                    TheFilter = (o, prefix) => (((Group_Set)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Group_Set)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASProfile = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                    ASProfile.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertParaProfileOrGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                Group_Set POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.GroupSetMaster.Where(x => x.para_prof_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Group_Set>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Group_Set>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null && SEO_QMS_M030_D != null) // Only enter in the code block if ENtity Not null.
                {
                    SEO_QMS_M030_D.gc_or_ss = POPUPEntityObject.para_prof_code;
                    SEO_QMS_M030_D.plant_gc = POPUPEntityObject.location_id;
                    SEO_QMS_M030_D.line_id_ic = InspCharEntity[dgSelectedIndexInspChar].line_id;
                    SEO_QMS_M030_D.line_id_op = SEO_QMS_M030_B.line_id;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertParameterType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M032_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ParaTypeMaster.Where(x => x.para_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M032_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M032_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null && SEO_QMS_M030_C != null) // Only enter in the code block if ENtity Not null.
                {
                    if (InspCharEntity.Count > 0)
                    {
                        if (NewRow == true && AllowDuplicate == true)
                        {
                            SelectedSetEntity.Add(new QMS_M030_D()
                            {
                                id = 0,
                                para_type = POPUPEntityObject.para_type,
                                ParaName = POPUPEntityObject.cat_type_desc,
                                operation_no = SEO_QMS_M030_C.operation_no,
                                insp_char = SEO_QMS_M030_C.insp_char,
                                comp_code = MasterEntity.comp_code,
                                location_Id = MasterEntity.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                add_date = System.DateTime.Now,
                                edit_date = System.DateTime.Now,
                                t_status = "Draft",
                                active = true,
                                line_id_ic = InspCharEntity[dgSelectedIndexInspChar].insp_char_no,
                                line_id_op = SEO_QMS_M030_B.line_id
                            });
                        }
                        else if (dgSelectedIndexSet >= 0 && SelectedSetEntity.Count > dgSelectedIndexSet) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            SEO_QMS_M030_D.para_type = POPUPEntityObject.para_type;
                            SEO_QMS_M030_D.ParaName = POPUPEntityObject.cat_type_desc;
                            SEO_QMS_M030_D.operation_no = SEO_QMS_M030_C.operation_no;
                            SEO_QMS_M030_D.insp_char = SEO_QMS_M030_C.insp_char;
                            SEO_QMS_M030_D.comp_code = MasterEntity.comp_code;
                            SEO_QMS_M030_D.location_Id = MasterEntity.location_Id;
                            SEO_QMS_M030_D.add_by = AppSessionState.UserID;
                            SEO_QMS_M030_D.editby = AppSessionState.UserID;
                            SEO_QMS_M030_D.t_status = "Draft";
                            SEO_QMS_M030_D.active = true;
                            SEO_QMS_M030_D.line_id_op = SEO_QMS_M030_B.line_id;

                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("First Fill Insp.Char Tab Details And Then Select Parameter Type");
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M030> result)
        {
            MasterEntity = new QMS_M030();
            InspCharEntity = new ObservableCollection<QMS_M030_C>();
            OperationEntity = new ObservableCollection<QMS_M030_B>();
            AssignmentEntity = new ObservableCollection<QMS_M030_A>();
            SelectedSetEntity = new ObservableCollection<QMS_M030_D>();
            DefaultValues();
            NewRecord = true;
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M030> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_M030> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_QMS_M030_A = obj.ObjectToXML(AssignmentEntity);
                    MasterEntity.XmlDataDocument_QMS_M030_B = obj.ObjectToXML(OperationEntity);
                    MasterEntity.XmlDataDocument_QMS_M030_C = obj.ObjectToXML(InspCharEntity);
                    MasterEntity.XmlDataDocument_QMS_M030_D = obj.ObjectToXML(SelectedSetEntity);
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M030>(MasterEntity, "InspectionPlan", "QMS");
                        Copy = false;
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M030>(MasterEntity, "InspectionPlan", "QMS");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.plan_no != null || MasterEntity.plan_no != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    var msg = new NotificationMessage(ts_code_vm);
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M030> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Filter For Flip Grid
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
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
        public bool Filter(object obj)
        {
            var data = obj as QMS_M030_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.plan_no != null && data.plan_no.ToLower().Contains(_filterString.ToLower()) ||
                            data.plan_date != null && data.plan_date.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ItemCode != null && data.ItemCode.ToString().Contains(_filterString.ToLower()) ||
                            data.lot_size_from != null && data.lot_size_from.ToString().Contains(_filterString.ToLower()) ||
                            data.lot_size_to != null && data.lot_size_to.ToString().Contains(_filterString.ToLower()) ||
                            data.ItemCode != null && data.ItemCode.ToString().Contains(_filterString.ToLower()) ||
                            data.ItemName != null && data.ItemName.ToString().Contains(_filterString.ToLower()) ||
                            data.location_Id != null && data.location_Id.ToString().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Work Center
        private string _FilterStringItemCode;
        public string FilterStringItemCode
        {
            get { return _FilterStringItemCode; }
            set
            {
                _FilterStringItemCode = value;
                RaisePropertyChanged("FilterStringItemCode");
                FilterItemCode();
            }
        }
        private void FilterItemCode()
        {
            if (_ItemCodeCollection != null)
            {
                _ItemCodeCollection.Refresh();
            }
        }
        public bool FilterItemCollection(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringItemCode))
                {
                    return (data.ItemCode != null && data.ItemCode.ToLower().Contains(_FilterStringItemCode.ToLower()) ||
                            data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringItemCode.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Insp. Char
        private string _FilterStringChar;
        public string FilterStringChar
        {
            get { return _FilterStringChar; }
            set
            {
                _FilterStringChar = value;
                RaisePropertyChanged("FilterStringChar");
                FilterInspChar();
            }
        }
        private void FilterInspChar()
        {
            if (_InspCharCollection != null)
            {
                _InspCharCollection.Refresh();
            }
        }
        public bool FilterInspCharCollection(object obj)
        {
            var data = obj as QMS_M030_I_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringChar))
                {
                    return (data.insp_char != null && data.insp_char.ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.char_desc != null && data.char_desc.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.insp_char_type != null && data.insp_char_type.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.lower_limit != null && data.lower_limit.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.upp_limit != null && data.upp_limit.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.from_date != null && data.from_date.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.inspector_qualification != null && data.inspector_qualification.ToString().ToLower().Contains(_FilterStringChar.ToLower()) ||
                            data.insp_char_location != null && data.insp_char_location.ToString().ToLower().Contains(_FilterStringChar.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Parameter Collection
        private string _FilterStringPara;
        public string FilterStringPara
        {
            get { return _FilterStringPara; }
            set
            {
                _FilterStringPara = value;
                RaisePropertyChanged("FilterStringPara");
                FilterPara();
            }
        }
        private void FilterPara()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool FilterParameterCollection(object obj)
        {
            var data = obj as QMS_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringPara))
                {
                    return (data.para_type != null && data.para_type.ToLower().Contains(_FilterStringPara.ToLower()) ||
                            data.cat_type_desc != null && data.cat_type_desc.ToString().ToLower().Contains(_FilterStringPara.ToLower())

                            );
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region Event Handler
        void ModelUpdated_Operation(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "location_Id")
                    {
                        if (MC.WorkCenter.Where(x => x.location_Id == SEO_QMS_M030_B.location_Id && x.wc_code == SEO_QMS_M030_B.wc_code).ToList().Count == 0)
                        {
                            SEO_QMS_M030_B.wc_code = null;
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
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (OperationEntity.Count > dgSelectedIndexOperation && dgSelectedIndexOperation >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForOperationEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M030_B item in e.NewItems)
                        item.PropertyChanged += this.ModelUpdated_Operation;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M030_B item in e.OldItems)
                        item.PropertyChanged -= this.ModelUpdated_Operation;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M030_B item in e.NewItems)
                    {
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.active = true;
                        item.add_date = System.DateTime.Now;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.t_status = "Draft";
                        item.valid_from = System.DateTime.Now;
                        item.line_id = OperationEntity.Count;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    QMS_M030_B temp = (QMS_M030_B)e.OldItems[0];
                    var itemToRemove1 = OperationEntity.Where(x => (x.operation_no == temp.operation_no && x.operation_no == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.operation_no == "")
                        {
                            OperationEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }


        #endregion
    }
}
