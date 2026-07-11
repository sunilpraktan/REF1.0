using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.ReportingServices;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_VM : WorkspaceViewModel<MM_T001>
    {

        #region Variable Declaration

        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repositoryM = new WebServiceRepository<MC_MM_T001>();
        MC_MM_T001 MCTemp = new MC_MM_T001();
        MC_MM_T001 MCIndent = new MC_MM_T001();
        ObjectSerializationService objSer = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private List<MM_M001> _store_temp_list;
        public List<MM_M001> store_temp_list
        {
            get { return _store_temp_list; }
            set
            {
                if (_store_temp_list != value)
                {
                    _store_temp_list = value;


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

        private List<ZADM_M013_P> _MachineCode_temp_list;
        public List<ZADM_M013_P> MachineCode_temp_list
        {
            get { return _MachineCode_temp_list; }
            set
            {
                if (_MachineCode_temp_list != value)
                {
                    _MachineCode_temp_list = value;
                }
            }
        }

        private List<ADM_M022_P> _ItemsList = new List<ADM_M022_P>();
        public List<ADM_M022_P> ItemsList
        {
            get { return _ItemsList; }
            set
            {
                if (_ItemsList != value)
                {
                    _ItemsList = value;

                    RaisePropertyChanged("ItemsList");
                }
            }
        }
        string store_location = null;

        MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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

        //mov type is not change after save 
        private bool _MoveFlag;
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private bool _LockAfterSave;
        public bool LockAfterSave
        {
            get { return _LockAfterSave; }
            set { _LockAfterSave = value; RaisePropertyChanged("LockAfterSave"); }
        }

        private MM_T001 _MasterEntity;
        public MM_T001 MasterEntity
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

        private MM_T001 _MasterEntityTemp;
        public MM_T001 MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        public List<ADM_M003> _ObjSupply = new List<ADM_M003>();
        private List<ADM_M003> ObjSupply
        {
            get { return _ObjSupply; }
            set
            {
                if (_ObjSupply != value)
                {
                    _ObjSupply = value;
                }
            }
        }
        public List<ADM_M002> _ObjSupplyCompany = new List<ADM_M002>();
        private List<ADM_M002> ObjSupplyCompany
        {
            get { return _ObjSupplyCompany; }
            set
            {
                if (_ObjSupplyCompany != value)
                {
                    _ObjSupplyCompany = value;
                }
            }
        }


        private ObservableCollection<MM_T001_A> _GoodsIssueDetails;
        public ObservableCollection<MM_T001_A> GoodsIssueDetails
        {
            get { return _GoodsIssueDetails; }
            set
            {
                if (_GoodsIssueDetails != value)
                {
                    _GoodsIssueDetails = value;

                    RaisePropertyChanged("GoodsIssueDetails");

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
                    FilterBatchDataGrid();
                }
            }
        }
        private List<PPC_T001_P> _tempOrderList;
        public List<PPC_T001_P> tempOrderList
        {
            get { return _tempOrderList; }
            set
            {
                if (_tempOrderList != value)
                {
                    _tempOrderList = value;
                    RaisePropertyChanged("tempOrderList");
                }
            }
        }

        private List<MM_T001Flip> _FlipGridData;
        public List<MM_T001Flip> FlipGridData
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

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }
        private int _ParadgSelectedIndex;

        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }

        private ObservableCollection<MM_T001_B> _dgBatchEntity = new ObservableCollection<MM_T001_B>();
        public ObservableCollection<MM_T001_B> dgBatchEntity
        {
            get
            {
                return _dgBatchEntity;
            }
            set
            {
                if (_dgBatchEntity != value)
                {
                    _dgBatchEntity = value;
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForBatch function evry time. which will not work after one time use earlier.
                    _dgBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
                    RaisePropertyChanged("dgBatchEntity");
                }
            }
        }
        private ObservableCollection<MM_T001_B> _ItemBatch_list = new ObservableCollection<MM_T001_B>();
        public ObservableCollection<MM_T001_B> ItemBatch_list
        {
            get { return _ItemBatch_list; }
            set
            {
                if (_ItemBatch_list != value)
                {
                    _ItemBatch_list = value;

                    RaisePropertyChanged("ItemBatch_list");
                }
            }
        }

        private int _dgSelectedBatchindex;
        public int dgSelectedBatchindex
        {
            get
            {
                return _dgSelectedBatchindex;
            }
            set
            {
                if (_dgSelectedBatchindex != value)
                {
                    _dgSelectedBatchindex = value;
                    RaisePropertyChanged("dgSelectedBatchindex");
                }
            }
        }
        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
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

        private DateTime _FromDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }

        private DateTime _ToDate;
        public DateTime ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
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

        #region Autosuggest Initialization
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
        private DataGridCellInfo _cellInfoBatch;
        public DataGridCellInfo CellInfoBatch
        {
            get { return _cellInfoBatch; }
            set
            {
                _cellInfoBatch = value;
                SetAutoTextSourceBatch(_cellInfoBatch);
                RaisePropertyChanged("CellInfoBatch");
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
                    { ASDefault = ASItem; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "machinecode")
                    { ASDefault = ASMachine; }
                    else if (SourceName == "batch_no")
                    { ASDefault = ASBatchItem; }
                    else if (SourceName == "store_code")
                    { ASDefault = ASStore; }
                    else if (SourceName == "location_Id")
                    { ASDefault = ASPlant; }

                }
            }
        }
        private void SetAutoTextSourceBatch(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "ItemCode")
                    { ASDefaultBatch = ASItem; }
                    else if (SourceName == "unit_code")
                    { ASDefaultBatch = ASUnit; }
                    else if (SourceName == "machinecode")
                    { ASDefaultBatch = ASMachine; }
                    else if (SourceName == "batch_no")
                    { ASDefaultBatch = ASBatch; }
                    else if (SourceName == "store_code")
                    { ASDefaultBatch = ASStore; }
                    else if (SourceName == "location_Id")
                    { ASDefaultBatch = ASPlant; }

                }
            }
        }
        public Func<object, string, bool> TheFilter { get; set; }
        public Func<object, string, bool> TheFilter2 { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public static IValueConverter SuggestedValue2 { get; set; }
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

        private AutoSuggestTextViewModel<dynamic> _ASDefaultBatch { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefaultBatch
        {
            get { return _ASDefaultBatch; }
            set
            {
                if (_ASDefaultBatch != value)
                {
                    _ASDefaultBatch = value; RaisePropertyChanged("ASDefaultBatch");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Movement { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Movement
        {
            get { return _AS_Movement; }
            set
            {
                if (_AS_Movement != value)
                {
                    _AS_Movement = value; RaisePropertyChanged("AS_Movement");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Requester { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Requester
        {
            get { return _AS_Requester; }
            set
            {
                if (_AS_Requester != value)
                {
                    _AS_Requester = value; RaisePropertyChanged("AS_Requester");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDepartment
        {
            get { return _ASDepartment; }
            set
            {
                if (_ASDepartment != value)
                {
                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
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

        private AutoSuggestTextViewModel<dynamic> _ASIndent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIndent
        {
            get { return _ASIndent; }
            set
            {
                if (_ASIndent != value)
                {
                    _ASIndent = value; RaisePropertyChanged("ASIndent");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASOrder { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrder
        {
            get { return _ASOrder; }
            set
            {
                if (_ASOrder != value)
                {
                    _ASOrder = value; RaisePropertyChanged("ASOrder");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASMachine { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMachine
        {
            get { return _ASMachine; }
            set
            {
                if (_ASMachine != value)
                {
                    _ASMachine = value; RaisePropertyChanged("ASMachine");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBatchItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBatchItem
        {
            get { return _ASBatchItem; }
            set
            {
                if (_ASBatchItem != value)
                {
                    _ASBatchItem = value; RaisePropertyChanged("ASBatchItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBatch { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBatch
        {
            get { return _ASBatch; }
            set
            {
                if (_ASBatch != value)
                {
                    _ASBatch = value; RaisePropertyChanged("ASBatch");
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
        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value; RaisePropertyChanged("ASCompany");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStore { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStore
        {
            get { return _ASStore; }
            set
            {
                if (_ASStore != value)
                {
                    _ASStore = value; RaisePropertyChanged("ASStore");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Indent { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Indent
        {
            get { return _AS_Indent; }
            set
            {
                if (_AS_Indent != value)
                {
                    _AS_Indent = value; RaisePropertyChanged("AS_Indent");
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
        #endregion

        #region Validation Region
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;

        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion

        #region ICollection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _CollectionRequester;
        public ICollectionView CollectionRequester
        {
            get { return _CollectionRequester; }
            set { _CollectionRequester = value; RaisePropertyChanged("CollectionRequester"); }
        }
        private ICollectionView _CollectionDepartment;
        public ICollectionView CollectionDepartment
        {
            get { return _CollectionDepartment; }
            set { _CollectionDepartment = value; RaisePropertyChanged("CollectionDepartment"); }
        }
        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private ICollectionView _CollectionMovType;
        public ICollectionView CollectionMovType
        {
            get { return _CollectionMovType; }
            set { _CollectionMovType = value; RaisePropertyChanged("CollectionMovType"); }
        }

        private ICollectionView _CollectionItem;
        public ICollectionView CollectionItem
        {
            get { return _CollectionItem; }
            set { _CollectionItem = value; RaisePropertyChanged("CollectionItem"); }
        }
        private ICollectionView _CollectionUnit;
        public ICollectionView CollectionUnit
        {
            get { return _CollectionUnit; }
            set { _CollectionUnit = value; RaisePropertyChanged("CollectionUnit"); }
        }
        private ICollectionView _CollectionCompany;
        public ICollectionView CollectionCompany
        {
            get { return _CollectionCompany; }
            set { _CollectionCompany = value; RaisePropertyChanged("CollectionCompany"); }
        }
        private ICollectionView _CollectionPlant_A;
        public ICollectionView CollectionPlant_A
        {
            get { return _CollectionPlant_A; }
            set { _CollectionPlant_A = value; RaisePropertyChanged("CollectionPlant_A"); }
        }
        private ICollectionView _CollectionStoreLocation;
        public ICollectionView CollectionStoreLocation
        {
            get { return _CollectionStoreLocation; }
            set { _CollectionStoreLocation = value; RaisePropertyChanged("CollectionStoreLocation"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection")
                ;
            }
        }

        private ICollectionView _TotalParameterCollection;
        public ICollectionView TotalParameterCollection
        {
            get { return _TotalParameterCollection; }
            set
            {
                _TotalParameterCollection = value;
                RaisePropertyChanged("TotalParameterCollection")
               ;
            }
        }
        private ICollectionView _batchCollection;
        public ICollectionView batchCollection
        {
            get { return _batchCollection; }
            set
            {
                _batchCollection = value;
                RaisePropertyChanged("batchCollection")
               ;
            }
        }
        private ICollectionView _CollectionIndent;
        public ICollectionView CollectionIndent
        {
            get { return _CollectionIndent; }
            set { _CollectionIndent = value; RaisePropertyChanged("CollectionIndent"); }
        }

        private ICollectionView _NotificationDataCollection;
        public ICollectionView NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set { _NotificationDataCollection = value; RaisePropertyChanged("NotificationDataCollection"); }
        }


        private ICollectionView _AttachmentCollection;
        public ICollectionView AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

        private ICollectionView _collectionOrderNo;
        public ICollectionView collectionOrderNo
        {
            get { return _collectionOrderNo; }
            set { _collectionOrderNo = value; RaisePropertyChanged("collectionOrderNo"); }
        }

        private ICollectionView _MachineCodeCollection;
        public ICollectionView MachineCodeCollection
        {
            get { return _MachineCodeCollection; }
            set { _MachineCodeCollection = value; RaisePropertyChanged("MachineCodeCollection"); }
        }

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        #region Temp Variables

        private ICollectionView _dataGridview;
        public ICollectionView DataGridView
        {
            get { return _dataGridview; }
            set { _dataGridview = value; RaisePropertyChanged("DataGridView"); }
        }

        #endregion

        #endregion

        #region StringList Variables


        List<string> _strListMovement;
        public List<string> StringListMovement
        {
            get { return _strListMovement; }
            set
            {
                if (_strListMovement != value)
                {
                    _strListMovement = value;
                }
            }
        }



        List<string> _strListRequster;
        public List<string> StringListRequster
        {
            get { return _strListRequster; }
            set
            {
                if (_strListRequster != value)
                {
                    _strListRequster = value;
                }
            }
        }


        List<string> _strListDept;
        public List<string> StringListDept
        {
            get { return _strListDept; }
            set
            {
                if (_strListDept != value)
                {
                    _strListDept = value;
                }
            }
        }

        List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }

        List<string> _stringListUOM;
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


        List<string> _stringListPlant;
        public List<string> stringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }

        List<string> _stringListStoreLoc;
        public List<string> stringListStoreLoc
        {
            get { return _stringListStoreLoc; }
            set
            {
                if (_stringListStoreLoc != value)
                {
                    _stringListStoreLoc = value;
                }
            }
        }

        List<string> _stringListBatch;
        public List<string> stringListBatch
        {
            get { return _stringListBatch; }
            set
            {
                if (_stringListBatch != value)
                {
                    _stringListBatch = value;
                    RaisePropertyChanged("stringListBatch");
                }
            }
        }
        List<string> _stringListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _stringListItemCategory; }
            set
            {
                if (_stringListItemCategory != value)
                {
                    _stringListItemCategory = value;
                }
            }
        }
        List<string> _strListIndent;
        public List<string> StringListIndent
        {
            get { return _strListIndent; }
            set
            {
                if (_strListIndent != value)
                {
                    _strListIndent = value;
                }
            }
        }

        List<string> _stringListOrderNo;
        public List<string> StringListOrderNo
        {
            get { return _stringListOrderNo; }
            set
            {
                if (_stringListOrderNo != value)
                {
                    _stringListOrderNo = value;
                    RaisePropertyChanged("StringListOrderNo");
                }
            }
        }

        List<string> _strListMachineCode;
        public List<string> StringListMachineCode
        {
            get { return _strListMachineCode; }
            set
            {
                if (_strListMachineCode != value)
                {
                    _strListMachineCode = value;
                    RaisePropertyChanged("StringListMachineCode");
                }
            }
        }

        #endregion

        #region RelayCommand
        public RelayCommand<object> SelectionChangedCommandRequester
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandOrderDocNo
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandDepartment
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandMovType
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandItem
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandUnit
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandMasterCompany
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandMasterPlant
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandCompany
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandPlantA
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandStoreLocation
        {
            get;
            private set;
        }

        public RelayCommand<object> ParameterPopupCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> CollectionChangedMethod
        {
            get;
            private set;
        }
        public RelayCommand<object> CollectionChangedMethodbatch
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandIndent
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandGoodsIssueDetails
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandLoadIndentDetails
        {
            get;
            private set;
        }

        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> DataGridRowDeleteCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> DataGridRowDeleteCommandBatch
        {
            get;
            private set;
        }

        public RelayCommand<IList> batchSelectionCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandbatch
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedBatchDetailsCommand//clik 
        {
            get;
            private set;
        }

        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandMachine { get; private set; }

        public RelayCommand<object> cmdCopyAndPaste { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadRecords { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdExecuteReference { get; private set; }
        #endregion

        #region ADM_M022_PopUp Item Master

        private List<ADM_M022_P> _SelectedItemList;
        public List<ADM_M022_P> SelectedItemList
        {
            get { return _SelectedItemList; }
            set
            {
                if (_SelectedItemList != value)
                {
                    _SelectedItemList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertyChanged("SelectedItemList");
                    //}
                }
            }
        }


        #endregion

        #region MM_T003_PopUp
        private List<MM_T003_P> _SelectedIndentList;
        public List<MM_T003_P> SelectedIndentList
        {
            get { return _SelectedIndentList; }
            set
            {
                if (_SelectedIndentList != value)
                {
                    _SelectedIndentList = value;
                    RaisePropertyChanged("SelectedIndentList");
                }
            }
        }
        #endregion

        #region . Constructor .
        public MM_T001_VM(string ts_code)
            : base()
        {
            parameter = false;
            this.ts_code_vm = ts_code;
            MasterEntity = new MM_T001();
            FlipGridData = new List<MM_T001Flip>();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MM_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
            MC.GoodsA = new ObservableCollection<MM_T001_A>();
            MC = new MC_MM_T001();
            SelectedItemList = new List<ADM_M022_P>();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();
            MoveFlag = true;
            LockAfterSave = true;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            //MasterEntity.ValidateAsync().Wait();
            SelectedIndentList = new List<MM_T003_P>();

            dgBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);

            LoadInitialData();
            //DefaultValues(AppSessionState.TransactionCode);
            //this.ts_code = AppSessionState.TransactionCode;
            //if (AppSessionState.TransValue != null )
            //{
            //    LoadDocumentByDocumentNumber(AppSessionState.TransValue);
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        public MM_T001_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            parameter = false;
            MasterEntity = new MM_T001();
            FlipGridData = new List<MM_T001Flip>();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MM_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
            MC.GoodsA = new ObservableCollection<MM_T001_A>();
            MC = new MC_MM_T001();
            SelectedItemList = new List<ADM_M022_P>();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();
            MoveFlag = true;
            LockAfterSave = true;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            //MasterEntity.ValidateAsync().Wait();
            SelectedIndentList = new List<MM_T003_P>();
            dgBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            LoadInitialData();

            //if (doc_no != null && doc_no != "")
            //{
            //    LoadDocumentByDocumentNumber(doc_no, "DocumentNo");
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }

        #endregion

        #region . User Defined Function.
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "MI";
                MasterEntity.doc_type = "MI";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + AppSessionState.client;
                MC = repositoryM.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "Goods_Issue", "SCM", Request, 0, "LoadInitialData");

                #region Command Initialisation
                cmdCopyAndPaste = new RelayCommand<object>(items => { if (items == null) { return; } InsertRow_CopyPaste(items); });
                SelectionChangedCommandRequester = new RelayCommand<object>(items => { if (items == null) { return; } InsertRequster(items); });
                SelectionChangedCommandIndent = new RelayCommand<object>(items => { if (items == null) { return; } InsertIndentNo(items); });
                SelectionChangedCommandDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeptment(items); });
                SelectionChangedCommandMovType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                SelectionChangedCommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                SelectionChangedCommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Uom(cmdPara, false, true, true); });
                SelectionChangedCommandStoreLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });
                SelectionChangedCommandPlantA = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Plant(cmdPara, false, true, true); });
                SelectionChangedCommandCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Company(cmdPara, false, true, true); });
                SelectionChangedCommandbatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Batch(cmdPara, false, true, true); });
                SelectionChangedBatchDetailsCommand = new RelayCommand<object>(Items => { if (Items == null) { return; } GetSelectedBatchForItem(Items, true, false, true); });// used for batch popup on batch details tab
                SelectionChangedCommandOrderDocNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrderNoList(items); });
                DataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                DataGridRowDeleteCommandBatch = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_ItemBatch(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                batchSelectionCommand = new RelayCommand<IList>(items => { if (items == null) { return; } batchSelection(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
                SelectionChangedCommandMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_MachineCode(cmdPara, false, true, true); });
                cmdLoadRecords = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadRecords(); });
                SelectionChangedCommandMasterCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterCompany(items); });
                SelectionChangedCommandMasterPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterPlant(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdExecuteReference = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ExecuteReference(); });
                #endregion

                #region AutoSuggest Initialization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_T003_P)x).req_no);
                TheFilter = (o, prefix) => ((MM_T003_P)o).req_no.ToLower().Contains(prefix.ToLower());
                AS_Indent = new AutoSuggestTextViewModel<dynamic>(MC.IndentOrIndentNoList, TheFilter, SuggestedValue, "ref_doc", "req_no", true);
                AS_Indent.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M004_P)x).mov_tp);
                TheFilter = (o, prefix) => ((MM_M004_P)o).mov_tp.ToLower().Contains(prefix.ToLower()) || ((MM_M004_P)o).mov_tp_name.ToLower().Contains(prefix.ToLower());
                AS_Movement = new AutoSuggestTextViewModel<dynamic>(MC.MovementTypeList, TheFilter, SuggestedValue, "mov_tp", true);
                AS_Movement.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToLower().Contains(prefix.ToLower()) || ((ADM_M024_P)o).EmpName.ToLower().Contains(prefix.ToLower());
                AS_Requester = new AutoSuggestTextViewModel<dynamic>(MC.Requster, TheFilter, SuggestedValue, "EmpId", true);
                AS_Requester.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code);
                TheFilter = (o, prefix) => ((ADM_M025_P)o).dept_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M025_P)o).DeptName.ToLower().Contains(prefix.ToLower());
                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC.deptList, TheFilter, SuggestedValue, "dept_code", true);
                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.unitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.ToLower().Contains(prefix.ToLower()) || ((ADM_M022_P)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.items, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.ToLower().Contains(prefix.ToLower()) || ((ADM_M022_P)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.items, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_T001_B)x).batch_no);
                TheFilter = (o, prefix) => (((MM_T001_B)o).batch_no ?? "").ToLower().Contains(prefix.ToLower()) || ((MM_T001_B)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASDefaultBatch = new AutoSuggestTextViewModel<dynamic>(MC.ItemBatchDetails, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                ASDefaultBatch.AutoSuggestVM.IsEmptyValueAllowed = true;

                ObjSupplyCompany = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => ((ADM_M002)o).comp_code.ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>(ObjSupplyCompany, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                store_temp_list = (List<MM_M001>)AppSessionState.store_location;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001)x).store_code);
                TheFilter = (o, prefix) => ((MM_M001)o).store_code.ToLower().Contains(prefix.ToLower());
                ASStore = new AutoSuggestTextViewModel<dynamic>(store_temp_list, TheFilter, SuggestedValue, "store_code", "store_code", true);
                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;
                //store_location = (from o in store_temp_list
                //                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                // StringListStoreLoc = store_temp_list.Select(x => x.store_code).ToList();
                store_temp_list = ((List<MM_M001>)AppSessionState.store_location).Where(x => x.location_Id == AppSessionState.location_Id && x.client == AppSessionState.client).ToList();
                if (store_temp_list.Count == 1)
                {
                    store_location = store_temp_list[0].store_code;
                }

                var ConNoteCollection = (from o in MC.OrderDocNoList where (o.doc_cat == "OR" || o.doc_cat == "CN") select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
                TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((Order_No_P)o).ItemName.ToLower().Contains(prefix.ToLower()) || ((Order_No_P)o).party_name.ToLower().Contains(prefix.ToLower());
                ASOrder = new AutoSuggestTextViewModel<dynamic>(ConNoteCollection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_P)x).project_id);
                TheFilter = (o, prefix) => ((PRO_T001_P)o).project_id.ToLower().Contains(prefix.ToLower()) || ((PRO_T001_P)o).project_name.ToLower().Contains(prefix.ToLower());
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.Project, TheFilter, SuggestedValue, "project_id", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;

                if (MC.MachineCodeList.Count > 0)
                {
                    MachineCode_temp_list = (from o in MC.MachineCodeList
                                             where o.location_Id == AppSessionState.location_Id
                                             select o).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                    TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ZADM_M013_P)o).machine_id.ToString().StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                    ASMachine = new AutoSuggestTextViewModel<dynamic>(MachineCode_temp_list, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                    ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;
                }

                #endregion

                #region Load Collection

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                CollectionMovType = CollectionViewSource.GetDefaultView(MC.MovementTypeList);
                CollectionMovType.Filter = new Predicate<object>(FilterMovType);
                StringListMovement = MC.MovementTypeList.Select(x => x.mov_tp).ToList();

                CollectionRequester = CollectionViewSource.GetDefaultView(MC.Requster);
                CollectionRequester.Filter = new Predicate<object>(Filterrequest);
                StringListRequster = MC.Requster.Select(x => x.EmpId).ToList();

                CollectionDepartment = CollectionViewSource.GetDefaultView(MC.deptList);
                CollectionDepartment.Filter = new Predicate<object>(FilterDept);
                StringListDept = MC.deptList.Select(x => x.dept_code).ToList();

                CollectionItem = CollectionViewSource.GetDefaultView(MC.items);
                CollectionItem.Filter = new Predicate<object>(FilterItems);
                StringListItems = MC.items.Select(x => x.ItemCode).ToList();

                CollectionUnit = CollectionViewSource.GetDefaultView(MC.unitList);
                CollectionUnit.Filter = new Predicate<object>(FilterUnit);
                StringListUOM = MC.unitList.Select(x => x.unit_code).ToList();

                ObjSupplyCompany = (List<ADM_M002>)AppSessionState.ADM_M002_List;

                CollectionCompany = CollectionViewSource.GetDefaultView(ObjSupplyCompany.ToList());
                CollectionCompany.Filter = new Predicate<object>(FilterCompany);
                //stringListPlant = ObjSupply.Select(x => x.location_Id).ToList();

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                CollectionPlant_A = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                CollectionPlant_A.Filter = new Predicate<object>(FilterPlantA);
                stringListPlant = ObjSupply.Select(x => x.location_Id).ToList();

                store_temp_list = (List<MM_M001>)AppSessionState.store_location;
                CollectionStoreLocation = CollectionViewSource.GetDefaultView(store_temp_list);
                CollectionStoreLocation.Filter = new Predicate<object>(FilterStoreLoc);

                //store_location = (from o in store_temp_list
                //                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                //StringListStoreLoc = store_temp_list.Select(x => x.store_code).ToList();
                store_temp_list = ((List<MM_M001>)AppSessionState.store_location).Where(x => x.location_Id == AppSessionState.location_Id && x.client == AppSessionState.client).ToList();
                if (store_temp_list.Count == 1)
                {
                    store_location = store_temp_list[0].store_code;
                }


                CollectionIndent = CollectionViewSource.GetDefaultView(MC.IndentOrIndentNoList);
                CollectionIndent.Filter = new Predicate<object>(FilterIndent);
                StringListIndent = MC.IndentOrIndentNoList.Select(x => x.req_no).ToList();


                NotificationDataCollection = CollectionViewSource.GetDefaultView(MC.NotificationData);

                #endregion

                DefaultValues();
                MasterEntity.post_date = DateTime.Now;

                var msg = new NotificationMessage("MM_T001_VM");
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
        private void LoadRecords()
        {
            if (FromDate == null || ToDate == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select From Date And To Date Before Loading");
                showMessageService.ShowMessage();
            }
            else
            {
                string Request = "LoadRecordsofSelectedDate" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + "MI" + "!@" + Convert.ToDateTime(FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MM_T001>(MCTemp, Request, "Goods_Issue", "SCM", "LoadRecordsofSelectedDate", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Refresh();
            }
        }
        // used for batch up on Item Details Tab
        private void InsertDataGridRow_Batch_Org(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                MM_S003_P POPUPEntityObject = null;

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
                            POPUPEntityObject = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.ItemCode.Equals(GoodsIssueDetails[dgSelectedIndex].ItemCode) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            //GoodsIssueDetails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;


                            var Batchtemp = (from o in dgBatchEntity where o.ItemCode == POPUPEntityObject.ItemCode && o.sku == POPUPEntityObject.sku select o).ToList();

                            if (POPUPEntityObject.stock_total >= GoodsIssueDetails[dgSelectedIndex].qty)
                            {
                                if (Batchtemp.Count == 0)
                                {
                                    GoodsIssueDetails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;

                                    dgBatchEntity.Add(new MM_T001_B()
                                    {
                                        ItemCode = POPUPEntityObject.ItemCode,
                                        batch_no = POPUPEntityObject.batch_no,
                                        store_code = POPUPEntityObject.store_code,
                                        unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code,
                                        qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                                        comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code,
                                        location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id,
                                        add_by = AppSessionState.UserID,
                                        sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id,
                                        item_line_id = GoodsIssueDetails[dgSelectedIndex].id,
                                        rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                                        sku = POPUPEntityObject.sku,
                                        t_status = MasterEntity.t_status,
                                        active = true

                                    });
                                }

                                else if (Batchtemp.Count == 1)
                                {
                                    var record = dgBatchEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku).FirstOrDefault();
                                    int IndexOfrecord = dgBatchEntity.IndexOf(dgBatchEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku).FirstOrDefault());

                                    dgBatchEntity[IndexOfrecord].ItemCode = POPUPEntityObject.ItemCode;
                                    dgBatchEntity[IndexOfrecord].batch_no = POPUPEntityObject.batch_no;
                                    dgBatchEntity[IndexOfrecord].store_code = POPUPEntityObject.store_code;
                                    dgBatchEntity[IndexOfrecord].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                                    dgBatchEntity[IndexOfrecord].sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                                    dgBatchEntity[IndexOfrecord].item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                                    dgBatchEntity[IndexOfrecord].qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                                    dgBatchEntity[IndexOfrecord].rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                                    dgBatchEntity[IndexOfrecord].comp_code = MasterEntity.comp_code;
                                    dgBatchEntity[IndexOfrecord].location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                                    dgBatchEntity[IndexOfrecord].add_by = AppSessionState.UserID;
                                    dgBatchEntity[IndexOfrecord].sku = POPUPEntityObject.sku;
                                    dgBatchEntity[IndexOfrecord].t_status = GoodsIssueDetails[dgSelectedIndex].t_status;
                                    dgBatchEntity[IndexOfrecord].active = true;
                                    GoodsIssueDetails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;
                                }
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Batch Not Selected. Batch Available Quantity {0} is Less than Item Quantity {1}", POPUPEntityObject.stock_total, GoodsIssueDetails[dgSelectedIndex].qty);
                                showMessageService.ShowMessage();
                            }


                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].batch_no != POPUPEntityObject.batch_no)
                        {
                            GoodsIssueDetails[dgSelectedIndex].batch_no = "";
                            dgBatchEntity[dgSelectedBatchindex].ItemCode = POPUPEntityObject.ItemCode;
                            dgBatchEntity[dgSelectedBatchindex].batch_no = POPUPEntityObject.batch_no;
                            dgBatchEntity[dgSelectedBatchindex].store_code = POPUPEntityObject.store_code;
                            dgBatchEntity[dgSelectedBatchindex].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                            dgBatchEntity[dgSelectedBatchindex].sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                            dgBatchEntity[dgSelectedBatchindex].item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                            dgBatchEntity[dgSelectedBatchindex].qty = dgBatchEntity[dgSelectedBatchindex].qty > 0 ? dgBatchEntity[dgSelectedBatchindex].qty : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].rec_qty = dgBatchEntity[dgSelectedBatchindex].qty > 0 ? dgBatchEntity[dgSelectedBatchindex].qty : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = GoodsIssueDetails[dgSelectedIndex].sku;
                            dgBatchEntity[dgSelectedBatchindex].t_status = GoodsIssueDetails[dgSelectedIndex].t_status;
                            dgBatchEntity[dgSelectedBatchindex].active = true;
                            dgBatchEntity[dgSelectedBatchindex].client = AppSessionState.client;
                        }

                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_Batch(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                MM_S003_P POPUPEntityObject = null;

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
                            POPUPEntityObject = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.ItemCode.Equals(GoodsIssueDetails[dgSelectedIndex].ItemCode) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgBatchEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgBatchEntity.IndexOf(dgBatchEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (GoodsIssueDetails.Count > dgSelectedIndex && POPUPEntityObject.batch_no.Trim() != "")
                    {
                        if (IndexOfExistValue == -1)
                        {
                            GoodsIssueDetails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;

                            dgBatchEntity.Add(new MM_T001_B()
                            {
                                ItemCode = POPUPEntityObject.ItemCode,
                                batch_no = POPUPEntityObject.batch_no,
                                store_code = POPUPEntityObject.store_code,
                                unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code,
                                qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                                comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code,
                                location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id,
                                add_by = AppSessionState.UserID,
                                sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id,
                                item_line_id = GoodsIssueDetails[dgSelectedIndex].id,
                                rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                                sku = POPUPEntityObject.sku,
                                t_status = GoodsIssueDetails[dgSelectedIndex].t_status,
                                active = true

                            });
                        }
                        else if (IndexOfExistValue >= 0 && POPUPEntityObject.batch_no.Trim() != "")
                        {
                            GoodsIssueDetails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;
                            dgBatchEntity[IndexOfExistValue].ItemCode = POPUPEntityObject.ItemCode;
                            dgBatchEntity[IndexOfExistValue].batch_no = POPUPEntityObject.batch_no;
                            dgBatchEntity[IndexOfExistValue].store_code = POPUPEntityObject.store_code;
                            dgBatchEntity[IndexOfExistValue].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                            dgBatchEntity[IndexOfExistValue].sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                            dgBatchEntity[IndexOfExistValue].item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                            dgBatchEntity[IndexOfExistValue].qty = dgBatchEntity[IndexOfExistValue].qty > 0 ? dgBatchEntity[IndexOfExistValue].qty : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[IndexOfExistValue].rec_qty = dgBatchEntity[IndexOfExistValue].qty > 0 ? dgBatchEntity[IndexOfExistValue].qty : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[IndexOfExistValue].comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code;
                            dgBatchEntity[IndexOfExistValue].location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                            dgBatchEntity[IndexOfExistValue].add_by = AppSessionState.UserID;
                            dgBatchEntity[IndexOfExistValue].sku = GoodsIssueDetails[dgSelectedIndex].sku;
                            dgBatchEntity[IndexOfExistValue].t_status = GoodsIssueDetails[dgSelectedIndex].t_status;
                            dgBatchEntity[IndexOfExistValue].active = true;
                            dgBatchEntity[IndexOfExistValue].client = AppSessionState.client;
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
        // used for batch popup on batch details tab
        private void GetSelectedBatchForItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                MM_S003_P BatchDetails = new MM_S003_P();
                // MM_T001_B BatchDetails = new MM_T001_B();
                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();

                    if (Request.Length > 0)
                    {
                        try
                        {
                            BatchDetails = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.ItemCode.Equals(GoodsIssueDetails[dgSelectedIndex].ItemCode) == true).ToList()[0]; BatchDetails.Select = true;
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
                    {
                        BatchDetails = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                    }
                }

                #endregion

                if (BatchDetails != null)
                {
                    var InputValueIfExists = dgBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no && X.ItemCode == BatchDetails.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgBatchEntity.IndexOf(dgBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no && X.ItemCode == BatchDetails.ItemCode).FirstOrDefault()); // Prefer Primary Key for this instruction.

                    var FilteredBatch = (from o in dgBatchEntity
                                         where o.ItemCode == GoodsIssueDetails[dgSelectedIndex].ItemCode &&
                                         o.sku == GoodsIssueDetails[dgSelectedIndex].sku
                                         select o).ToList();



                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && FilteredBatch.Count == dgSelectedBatchindex && BatchDetails.Select == true)
                    {
                        dgBatchEntity.Add(new MM_T001_B()
                        {
                            ItemCode = BatchDetails.ItemCode,
                            unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code,
                            batch_no = BatchDetails.batch_no,
                            store_code = BatchDetails.store_code,
                            //qty = BatchDetails.stock_total,
                            qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                            rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty,
                            comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code,
                            location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id,
                            add_by = AppSessionState.UserID,
                            item_line_id = GoodsIssueDetails[dgSelectedIndex].id,
                            sku = BatchDetails.sku,
                            sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id,
                            active = true
                        });
                    }
                    else if (dgSelectedBatchindex >= 0 && BatchDetails.Select == true && dgBatchEntity.Count > dgSelectedBatchindex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgBatchEntity[dgSelectedBatchindex].ItemCode == null && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgBatchEntity[dgSelectedBatchindex].ItemCode = BatchDetails.ItemCode;
                            dgBatchEntity[dgSelectedBatchindex].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                            dgBatchEntity[dgSelectedBatchindex].batch_no = BatchDetails.batch_no;
                            dgBatchEntity[dgSelectedBatchindex].store_code = BatchDetails.store_code;
                            dgBatchEntity[dgSelectedBatchindex].qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = BatchDetails.sku;
                            dgBatchEntity[dgSelectedBatchindex].sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                            dgBatchEntity[dgSelectedBatchindex].item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                        }
                        else if (dgBatchEntity[dgSelectedBatchindex].batch_no != BatchDetails.batch_no)
                        {
                            dgBatchEntity[dgSelectedBatchindex].batch_no = BatchDetails.batch_no;
                        }
                        else
                        {
                            dgBatchEntity[dgSelectedBatchindex].ItemCode = BatchDetails.ItemCode;
                            dgBatchEntity[dgSelectedBatchindex].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                            dgBatchEntity[dgSelectedBatchindex].batch_no = BatchDetails.batch_no;
                            dgBatchEntity[dgSelectedBatchindex].store_code = BatchDetails.store_code;
                            dgBatchEntity[dgSelectedBatchindex].qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= BatchDetails.stock_total ? Convert.ToDecimal(BatchDetails.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                            dgBatchEntity[dgSelectedBatchindex].comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = BatchDetails.sku;
                            dgBatchEntity[dgSelectedBatchindex].sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                            dgBatchEntity[dgSelectedBatchindex].item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                        }
                    }
                }



                BatchDetails.Select = false;

                #region Clear Empty Row

                MM_T001_B newObj = new MM_T001_B();
                for (int i = dgBatchEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgBatchEntity[i].ComparePropertiesTo(newObj);
                    if (dgBatchEntity[i].ComparePropertiesTo(newObj) && dgBatchEntity.Count > 1)
                    {
                        dgBatchEntity.RemoveAt(i);
                        if (dgBatchEntity.Count == 0)
                        {
                            dgBatchEntity.Add(newObj);
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
        private void batchSelection(IList batchlist)
        {
            try
            {

                IList list = batchlist as IList;

                if (GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count && dgSelectedIndex != -1)
                {

                    List<MM_T001_A> selectionbatch = list.Cast<MM_T001_A>().ToList();
                    if (selectionbatch.Count > 0 && dgSelectedIndex != -1)
                    {

                        var temp = (from o in MC.batchList
                                    where o.ItemCode == selectionbatch[0].ItemCode && (o.sku ?? "") == (selectionbatch[0].sku ?? "") && o.store_code == selectionbatch[0].store_code
                                    select o);

                        var temp2 = (from o in MC.batchList
                                     where o.ItemCode == selectionbatch[0].ItemCode && (o.sku ?? "") == (selectionbatch[0].sku ?? "") && o.store_code == selectionbatch[0].store_code
                                     select o);

                        //batchCollection = CollectionViewSource.GetDefaultView(temp.ToList());
                        //batchCollection.Filter = new Predicate<object>(Filterbatch);
                        //stringListBatch = MC.batchList.Select(x => x.batch_no).ToList();

                        SuggestedValue2 = new ValueConverter(x => x == null ? "" : ((MM_S003_P)x).batch_no);
                        TheFilter2 = (o, prefix) => ((MM_S003_P)o).batch_no.ToLower().Contains(prefix.ToLower());
                        ASBatch = new AutoSuggestTextViewModel<dynamic>(temp2.ToList(), TheFilter2, SuggestedValue2, "batch_no", "batch_no", true);
                        ASBatch.AutoSuggestVM.IsEmptyValueAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_S003_P)x).batch_no);
                        TheFilter = (o, prefix) => (((MM_S003_P)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASBatchItem = new AutoSuggestTextViewModel<dynamic>(temp2.ToList(), TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                        ASBatchItem.AutoSuggestVM.IsEmptyValueAllowed = true;


                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
                        }
                    }

                    if (GoodsIssueDetails[dgSelectedIndex].id == 0)
                    {
                        LockAfterSave = true;
                    }
                    else
                    {
                        LockAfterSave = false;
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
        private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && dgBatchEntity.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (MM_T001_B item in e.NewItems)
                    {
                        item.ItemCode = GoodsIssueDetails[dgSelectedIndex].ItemCode;
                        item.batch_no = GoodsIssueDetails[dgSelectedIndex].batch_no;
                        item.store_code = GoodsIssueDetails[dgSelectedIndex].store_code;
                        item.unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                        //item.qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                        //item.rec_qty = (GoodsIssueDetails[dgSelectedIndex].qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : GoodsIssueDetails[dgSelectedIndex].qty;
                        item.comp_code = GoodsIssueDetails[dgSelectedIndex].comp_code;
                        item.location_Id = GoodsIssueDetails[dgSelectedIndex].location_Id;
                        item.add_by = AppSessionState.UserID;
                        item.sr_line_no = GoodsIssueDetails[dgSelectedIndex].line_id;
                        item.item_line_id = GoodsIssueDetails[dgSelectedIndex].id;
                        item.sku = GoodsIssueDetails[dgSelectedIndex].sku;
                        item.t_status = GoodsIssueDetails[dgSelectedIndex].t_status;
                        item.client = AppSessionState.client;
                        item.ref_batch_row_id = GoodsIssueDetails[dgSelectedIndex].id;
                        item.active = true;
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

            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //dgItemScheduleEntity.Remove(x => x.)
                //PUR_T002_B temp = (PUR_T002_B)e.NewItems[0];
                //foreach (var itemToRemove in dgItemScheduleEntity.Where(x => x.ItemCode == temp.ItemCode).ToList())
                //{
                //    dgItemScheduleEntity.Remove(itemToRemove);
                //}
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }
        }

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        private void FilterBatchDataGrid()
        {
            try
            {
                if (dgBatchEntity != null && dgBatchEntity.Count > 0 && dgSelectedIndex <= dgBatchEntity.Count && dgSelectedIndex >= 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(dgBatchEntity);
                    DataGridView.Filter = adv => ((MM_T001_B)adv).sr_line_no.Equals(GoodsIssueDetails[dgSelectedIndex].line_id);
                    DataGridView.Refresh();
                }
            }
            catch
            {

            }

        }
        private void InsertMovementType(object InputValue)
        {
            try
            {

                string Request = "";
                MM_M004_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.MovementTypeList.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.mov_tp = POPUPEntityObject.mov_tp;
                    MasterEntity.mov_name = POPUPEntityObject.mov_tp_name;

                    if (MasterEntity.mov_tp == "114")
                    {
                        var SoCollection = (from o in MC.OrderDocNoList where o.doc_cat == "SO" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
                        TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                        ASOrder = new AutoSuggestTextViewModel<dynamic>(SoCollection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (MasterEntity.mov_tp == "104")
                    {
                        var ProjectCollection = (from o in MC.OrderDocNoList where o.doc_cat == "PJ" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
                        TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                        ASOrder = new AutoSuggestTextViewModel<dynamic>(ProjectCollection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (MasterEntity.mov_tp == "103")
                    {

                        var ConNoteCollection = (from o in MC.OrderDocNoList where (o.doc_cat == "OR" || o.doc_cat == "CN") select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
                        TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                        ASOrder = new AutoSuggestTextViewModel<dynamic>(ConNoteCollection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else
                    {
                        var Collection = (from o in MC.OrderDocNoList where o.doc_cat == "ZZ" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
                        TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                        ASOrder = new AutoSuggestTextViewModel<dynamic>(Collection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void InsertOrderNoList(object InputValue)
        {
            try
            {

                string Request = "";
                Order_No_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.OrderDocNoList.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Order_No_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.order_doc_no = POPUPEntityObject.order_no;
                    MasterEntity.bom_no = POPUPEntityObject.bom_no;
                    MasterEntity.qty = POPUPEntityObject.order_qty;
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
        private void InsertRequster(object InputValue)
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
                            { POPUPEntityObject = MC.Requster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.Req_Name = POPUPEntityObject.EmpName;

                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.Dept_Name = POPUPEntityObject.DeptName;
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
        private void InsertDeptment(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M025_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.deptList.Where(x => x.dept_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {

                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.Dept_Name = POPUPEntityObject.DeptName;
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
        private void InsertMasterCompany(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M002 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = ObjSupplyCompany.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;
                    //MasterEntity.com = POPUPEntityObject.EmpName;
                    if (POPUPEntityObject.comp_code != "" || POPUPEntityObject.comp_code != null)
                    {
                        var myPlant = from data in ObjSupply
                                      where data.comp_code == POPUPEntityObject.comp_code
                                      select data;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                        TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
                        ASPlant = new AutoSuggestTextViewModel<dynamic>(myPlant.ToList(), TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                        ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else
                    {
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                        TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
                        ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                        ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void InsertMasterPlant(object InputValue)
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
                            { POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;

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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M022_P POPUPEntityObject = null;


                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.items.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                    var LineId = GoodsIssueDetails.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && GoodsIssueDetails.Count == dgSelectedIndex)
                    {
                        GoodsIssueDetails.Add(new MM_T001_A()
                        {
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            qty = POPUPEntityObject.qty,
                            unit_code = POPUPEntityObject.unit_code,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                            location_Id = MasterEntity.location_Id ?? AppSessionState.location_Id,
                            client = AppSessionState.client,
                            comp_code = MasterEntity.comp_code ?? AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            //posting_period = "1",
                            //fin_year = "15-16",
                            line_id = LineId,
                            store_code = store_location,
                            debcr_ind = "D",
                            mat_con = "New",
                            active = true,
                            order_no = MasterEntity.order_doc_no,
                            source_doc_no = MasterEntity.ref_doc ?? MasterEntity.order_doc_no,
                            doc_cat = MasterEntity.doc_cat,
                            doc_type = MasterEntity.doc_type,
                            doc_date = MasterEntity.doc_date,
                            mov_tp = MasterEntity.mov_tp,
                            post_date = MasterEntity.post_date,
                            order_doc_no = MasterEntity.order_doc_no
                        });

                    }

                    else if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            if (GoodsIssueDetails[dgSelectedIndex].line_id == 0)
                            {
                                GoodsIssueDetails[dgSelectedIndex].line_id = GoodsIssueDetails.Count;
                            }
                            GoodsIssueDetails[dgSelectedIndex].ItemCode = POPUPEntityObject.ItemCode;
                            GoodsIssueDetails[dgSelectedIndex].description = POPUPEntityObject.ItemName;
                            GoodsIssueDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            GoodsIssueDetails[dgSelectedIndex].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                            GoodsIssueDetails[dgSelectedIndex].active = true;
                            GoodsIssueDetails[dgSelectedIndex].SubCatCode = POPUPEntityObject.SubCatCode;
                            GoodsIssueDetails[dgSelectedIndex].location_Id = MasterEntity.location_Id ?? AppSessionState.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = MasterEntity.comp_code ?? AppSessionState.comp_code;
                            GoodsIssueDetails[dgSelectedIndex].client = AppSessionState.client;
                            GoodsIssueDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            GoodsIssueDetails[dgSelectedIndex].store_code = store_location;
                            GoodsIssueDetails[dgSelectedIndex].qty = POPUPEntityObject.qty;
                            GoodsIssueDetails[dgSelectedIndex].mat_con = "New";
                            GoodsIssueDetails[dgSelectedIndex].order_doc_no = MasterEntity.order_doc_no;
                            GoodsIssueDetails[dgSelectedIndex].debcr_ind = "D";
                            GoodsIssueDetails[dgSelectedIndex].order_no = MasterEntity.order_doc_no;
                            GoodsIssueDetails[dgSelectedIndex].source_doc_no = MasterEntity.ref_doc ?? MasterEntity.order_doc_no;
                            GoodsIssueDetails[dgSelectedIndex].doc_cat = MasterEntity.doc_cat;
                            GoodsIssueDetails[dgSelectedIndex].doc_type = MasterEntity.doc_type;
                            GoodsIssueDetails[dgSelectedIndex].doc_date = MasterEntity.doc_date;
                            GoodsIssueDetails[dgSelectedIndex].mov_tp = MasterEntity.mov_tp;
                            GoodsIssueDetails[dgSelectedIndex].post_date = MasterEntity.post_date;
                            GoodsIssueDetails[dgSelectedIndex].order_no = MasterEntity.order_doc_no;
                        }

                        else if (GoodsIssueDetails[dgSelectedIndex].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            GoodsIssueDetails[dgSelectedIndex].ItemCode = "";
                            GoodsIssueDetails[dgSelectedIndex].description = "";
                        }
                    }
                }

                //if (MC.MachineCodeList.Count > 0 && dgSelectedIndex > 0 && GoodsIssueDetails.Count > 0)
                //{
                //    MachineCode_temp_list = (from o in MC.MachineCodeList
                //                             where o.location_Id == GoodsIssueDetails[dgSelectedIndex - 1].location_Id
                //                             select o).ToList();
                //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                //    TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ZADM_M013_P)o).machine_id.ToString().StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                //    ASMachine = new AutoSuggestTextViewModel<dynamic>(MachineCode_temp_list, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                //    ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;
                //}

                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_Uom(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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

                            POPUPEntityObject = MC.unitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            GoodsIssueDetails[dgSelectedIndex].unit_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_Company(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M002 POPUPEntityObject = null;

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
                            POPUPEntityObject = ObjSupplyCompany.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];

                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.comp_code == POPUPEntityObject.comp_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].comp_code = POPUPEntityObject.comp_code;
                            GoodsIssueDetails[dgSelectedIndex].CompName = POPUPEntityObject.CompName;

                            if (POPUPEntityObject.comp_code != "" || POPUPEntityObject.comp_code != null)
                            {
                                var myPlant = from data in ObjSupply
                                              where data.comp_code == POPUPEntityObject.comp_code
                                              select data;

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
                                ASPlant = new AutoSuggestTextViewModel<dynamic>(myPlant.ToList(), TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;
                            }
                            else
                            {
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
                                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;
                            }
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].comp_code != POPUPEntityObject.comp_code)
                        {
                            GoodsIssueDetails[dgSelectedIndex].comp_code = "";

                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_Plant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].location_Id = POPUPEntityObject.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].Plant_Name = POPUPEntityObject.LoctnNm;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = POPUPEntityObject.comp_code;
                            MasterEntity.location_Id = POPUPEntityObject.location_Id;

                            if (POPUPEntityObject.location_Id != "" || POPUPEntityObject.location_Id != null)
                            {
                                var myStore = from data in store_temp_list
                                              where data.location_Id == POPUPEntityObject.location_Id
                                              select data;

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001)x).store_code);
                                TheFilter = (o, prefix) => ((MM_M001)o).store_code.ToLower().Contains(prefix.ToLower());
                                ASStore = new AutoSuggestTextViewModel<dynamic>(myStore, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;
                                if (store_temp_list.Count == 1)
                                {
                                    store_location = store_temp_list[0].store_code;
                                }
                            }
                            else
                            {
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001)x).store_code);
                                TheFilter = (o, prefix) => ((MM_M001)o).store_code.ToLower().Contains(prefix.ToLower());
                                ASStore = new AutoSuggestTextViewModel<dynamic>(store_temp_list, TheFilter, SuggestedValue, "store_code", "store_code", true);
                                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;
                            }
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].location_Id != POPUPEntityObject.location_Id)
                        {
                            GoodsIssueDetails[dgSelectedIndex].location_Id = "";

                        }
                    }
                }
                if (MC.MachineCodeList.Count > 0 && dgSelectedIndex >= 0 && GoodsIssueDetails.Count >= 0)
                {

                    MachineCode_temp_list = (from o in MC.MachineCodeList
                                             where o.location_Id == GoodsIssueDetails[dgSelectedIndex].location_Id
                                             select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                    TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ZADM_M013_P)o).machine_id.ToString().StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                    ASMachine = new AutoSuggestTextViewModel<dynamic>(MachineCode_temp_list, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                    ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;
                }

                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_MachineCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;

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
                            POPUPEntityObject = MachineCode_temp_list.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].machine_id = POPUPEntityObject.machine_id;
                            GoodsIssueDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                            GoodsIssueDetails[dgSelectedIndex].wc_code = POPUPEntityObject.wc_code;

                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                        {
                            GoodsIssueDetails[dgSelectedIndex].machinecode = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        private void InsertDataGridRow_StoreLocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M001 POPUPEntityObject = null;

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
                            POPUPEntityObject = store_temp_list.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].store_code = POPUPEntityObject.store_code;
                            GoodsIssueDetails[dgSelectedIndex].location_Id = POPUPEntityObject.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = POPUPEntityObject.comp_code;
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].store_code != POPUPEntityObject.store_code)
                        {
                            GoodsIssueDetails[dgSelectedIndex].store_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = GoodsIssueDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsIssueDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsIssueDetails[i].ComparePropertiesTo(newObj) == true && GoodsIssueDetails.Count > 1)
                    {
                        GoodsIssueDetails.RemoveAt(i);
                        if (GoodsIssueDetails.Count == 0)
                        {
                            GoodsIssueDetails.Add(newObj);
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
        //data grid batch 

        private void InsertIndentNo(object InputValue)//indent no selection
        {
            try
            {

                string Request = "";
                MM_T003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.IndentOrIndentNoList.Where(x => x.req_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<MM_T003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_T003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.PendingAck != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Privious Indent Acknowledgement Pending of {0}", POPUPEntityObject.PendingAck);
                        showMessageService.ShowMessage();
                        MasterEntity.ref_doc = "";
                    }
                    else
                    {
                        MasterEntity.ref_doc = POPUPEntityObject.req_no;
                    }
                }
                var msg = new NotificationMessage("MM_T001_VM");
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                string Request = "";
                string ParametersStringValue = "";
                MM_T001Flip ParameterEntityObject = null;

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        {
                            Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + "LoadIndentNo" + "!@" + MasterEntity.ref_doc + "!@" + AppSessionState.comp_code;

                        }

                        catch (Exception ex) { }
                        if (MasterEntity.ref_doc == null || MasterEntity.ref_doc == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Order Selection";
                            showMessageService.Text = String.Format("Please Select Order No", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            string movtp = MasterEntity.mov_tp;
                            string movname = MasterEntity.mov_name;
                            MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Issue", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                            MasterEntity.mov_tp = movtp;
                            MasterEntity.mov_name = movname;




                        }
                        DefaultValues();
                        if (ParametersStringValue == "ReferenceDocument")
                        {
                            MasterEntity.ts_code = ts_code_vm;
                            MasterEntity.ref_doc = MasterEntity.ref_doc;
                            MasterEntity.ref_doc_date = MasterEntity.doc_date;
                            MasterEntity.doc_cat = "MI";
                            MasterEntity.doc_type = "MI";
                            MasterEntity.doc_no = "";
                            MasterEntity.doc_date = DateTime.Now;
                            MasterEntity.post_date = DateTime.Now;
                            MasterEntity.add_by = AppSessionState.UserID;
                            MasterEntity.editby = AppSessionState.UserID;
                            //MasterEntity.fin_year = "15-16";
                            //MasterEntity.posting_period = "1";
                            MasterEntity.active = true;
                            MasterEntity.t_status = "001";
                            MasterEntity.add_by = AppSessionState.UserID;
                            MasterEntity.editby = AppSessionState.UserID;
                            MasterEntity.mov_tp = "103";
                            MasterEntity.mov_name = "Goods Issue for Production";
                            MasterEntity.client = AppSessionState.client;

                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList().Count > 0)
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList()[0];
                    {
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + "LoadMaterialIssueItemDetail" + "!@" + ParameterEntityObject.doc_no;
                        NewRecord = false;
                        MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Issue", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                        //MasterEntity.ts_code = this.ts_code;
                        AttachmentCollection = CollectionViewSource.GetDefaultView(MC.Attachment);
                        MoveFlag = false;
                        LockAfterSave = false;
                    }

                }

                MasterEntity.ts_code = ts_code_vm;


                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");

                parameter = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("MM_T001_VM");
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
        // below 4 methods are for Parameters and Parameter Values
        private void CollectionChanged(IList DataList)
        {
            IList list = DataList as IList;
            int a = dgSelectedIndex;
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            try
            {
                if (GoodsIssueDetails[dgSelectedIndex].id == 0 && GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
                {
                    List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && GoodsIssueDetails[dgSelectedIndex].sku != "" && GoodsIssueDetails[dgSelectedIndex].sku != null)
                        {
                            TempSkuList = GoodsIssueDetails[dgSelectedIndex].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    paramlist[i].parametervalue = TempParaValueList[0];
                                }
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                        else
                        {
                            foreach (var o in ParameterTemp)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {

                                    dgselectedindex = dgSelectedIndex,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name
                                });
                            }
                        }

                        if (GoodsIssueDetails[dgSelectedIndex].sku_desc != null)
                        {
                            SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                            foreach (var o in SelectedParaValueCollection)
                            {
                                foreach (var p in MC.ParamValueList)
                                {
                                    if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                    {
                                        o.value_code = p.value_code;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ParameterCollection = CollectionViewSource.GetDefaultView(TempParaValueList);
                    }
                }
                else if (GoodsIssueDetails[dgSelectedIndex].id != 0 && GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
                {
                    //List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();
                    //string[] TempSkuList = new string[100];
                    //List<string> TempParaValueList = new List<string>();

                    //if (SelectedRowlist[0].StockUnt == true)
                    //{
                    //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                    //    if (paramlist.Count > 0 && GoodsIssueDetails[dgSelectedIndex].sku != "" && GoodsIssueDetails[dgSelectedIndex].sku != null)
                    //    {
                    //        TempSkuList = GoodsIssueDetails[dgSelectedIndex].sku.Split('/');

                    //        for (int i = 0; i < paramlist.Count; i++)
                    //        {
                    //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                    //            paramlist[i].parametervalue = TempParaValueList[0];
                    //        }

                    //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                    //    }
                    //}
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
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {

                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                int a = ParadgSelectedIndex;
                int b = dgSelectedIndex;
                if (dgSelectedIndex != -1 && SelectedParaValueList.Count > 0 && GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
                {
                    if (GoodsIssueDetails[dgSelectedIndex].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndex)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();
                        }
                        #endregion
                    }
                    else if (GoodsIssueDetails[dgSelectedIndex].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            try
            {

                if (GoodsIssueDetails[dgSelectedIndex].sku_desc == null || GoodsIssueDetails[dgSelectedIndex].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((GoodsIssueDetails[dgSelectedIndex].sku_desc == "" || GoodsIssueDetails[dgSelectedIndex].sku_desc == null) && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku_desc = GoodsIssueDetails[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    GoodsIssueDetails[dgSelectedIndex].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((GoodsIssueDetails[dgSelectedIndex].sku_desc == "" || GoodsIssueDetails[dgSelectedIndex].sku_desc == null) && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku_desc = GoodsIssueDetails[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
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
        private void CalculateSku()
        {
            try
            {
                if (GoodsIssueDetails[dgSelectedIndex].StockUnt == true && (GoodsIssueDetails[dgSelectedIndex].sku == null || GoodsIssueDetails[dgSelectedIndex].sku == ""))
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].sku == "" || GoodsIssueDetails[dgSelectedIndex].sku == null)
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku = GoodsIssueDetails[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else if(GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
                {
                    GoodsIssueDetails[dgSelectedIndex].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].sku == "" || GoodsIssueDetails[dgSelectedIndex].sku == null)
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            GoodsIssueDetails[dgSelectedIndex].sku = GoodsIssueDetails[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
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
        private void InsertRow_CopyPaste(object InputRow)
        {
            try
            {
                MM_T001_A EntityObject = null;
                if (InputRow != null && dgSelectedIndex != -1 && GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
                {
                    if (((IEnumerable)InputRow).Cast<MM_T001_A>().Count() > 0)
                    {
                        EntityObject = ((IEnumerable)InputRow).Cast<MM_T001_A>().ToList()[0];
                        GoodsIssueDetails.Add(new MM_T001_A()
                        {
                            ItemCode = EntityObject.ItemCode,
                            description = EntityObject.description,
                            qty = EntityObject.qty,
                            unit_code = EntityObject.unit_code,
                            SubCatCode = EntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(EntityObject.StockUnt),
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            //posting_period = "1",
                            //fin_year = "15-16",
                            line_id = 0,
                            store_code = EntityObject.store_code,
                            debcr_ind = "D",
                            mat_con = EntityObject.mat_con,
                            sku = EntityObject.sku,
                            sku_desc = EntityObject.sku_desc,
                            doc_date = EntityObject.doc_date,
                            doc_type = EntityObject.doc_type,
                            doc_cat = EntityObject.doc_cat,
                            mov_tp = EntityObject.mov_tp,
                            unit_price = EntityObject.unit_price,
                            source_doc_type = EntityObject.source_doc_type,
                            source_doc_no = EntityObject.source_doc_no,
                            note = EntityObject.note,
                            Plant_Name = EntityObject.Plant_Name,
                            unit_Name = EntityObject.unit_Name,
                            SubCategCod = EntityObject.SubCategCod,
                            item_ok = EntityObject.item_ok,
                            machine_id = EntityObject.machine_id,
                            machinecode = EntityObject.machinecode,
                            active = true,
                            c_factor = EntityObject.c_factor,

                        });
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (GoodsIssueDetails.Count > i && GoodsIssueDetails[dgSelectedIndex].id == 0)
                {
                    for (int j = dgBatchEntity.Count - 1; j >= 0; j--)
                    {
                        if (GoodsIssueDetails[i].ItemCode == dgBatchEntity[j].ItemCode && GoodsIssueDetails[i].sku == dgBatchEntity[j].sku)
                        {
                            dgBatchEntity.Remove(dgBatchEntity[j]);
                        }
                    }
                    GoodsIssueDetails.RemoveAt(i);
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
        private void DeleteDataGridRow_ItemBatch(object InputValue)
        {
            int i = (int)InputValue;
            if (dgBatchEntity.Count > i && dgBatchEntity[dgSelectedBatchindex].id == 0)
            {
                dgBatchEntity.RemoveAt(i);
            }
        }
        private void ItemActiveInActiveMethod(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (GoodsIssueDetails.Count > i && GoodsIssueDetails[i].id != 0)
                {
                    if (GoodsIssueDetails[i].active == false)
                    {
                        foreach (var item in dgBatchEntity)
                        {
                            if (item.ItemCode == GoodsIssueDetails[i].ItemCode && item.sku == GoodsIssueDetails[i].sku && item.active == true)
                            {
                                item.active = false;
                            }
                        }
                    }
                }
                else if (GoodsIssueDetails[i].id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item {0} is Unsaved item. It is Recommanded to Delete This Item rather than inactivating it ", this.Title);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void ExecuteReference()
        {
            if (!string.IsNullOrWhiteSpace(MasterEntity.order_doc_no) && !string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MasterEntity.qty.HasValue)
            {
                MC_MM_T001 MCTempGRN = new MC_MM_T001();
                WebServiceRepository<MC_MM_T001> repositoryMG = new WebServiceRepository<MC_MM_T001>();
                string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + "MI" + "!@" + MasterEntity.order_doc_no + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                MCTempGRN = repositoryMG.GetDataWithReturnDomainObject<MC_MM_T001>(MCTempGRN, Request, "MM_T001_STD", "SCM", "LoadAll", 0, "");
                if (MCTempGRN.GRNMasterList != null)
                {
                    if (MCTempGRN.GRNMasterList.Count > 0)
                    {
                        MasterEntity = MCTempGRN.GRNMasterList[0];
                        GoodsIssueDetails = MCTempGRN.ItemDetailsList;
                        MasterEntity.ts_code = ts_code_vm;
                    }
                }
            }
        }
        #endregion

        #region · Command Actions ·
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "MI";
            MasterEntity.doc_code = "MI";
            MasterEntity.doc_type = "MI";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.vendor = null;
            MasterEntity.PartyId = null;
            MasterEntity.doc_date = DateTime.Now;
            //MasterEntity.fin_year = "15-16";
            //MasterEntity.posting_period = "1";
            MasterEntity.mov_tp = "103";
            MasterEntity.mov_name = "Goods Issue for Production";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.t_status = "004";
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;

        }
        private bool Validation()
        {

            if (GoodsIssueDetails.Count < 1)//when form is blank and we save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Insert Item........");
                showMessageService.ShowMessage();

                return false;
            }
            else if (MasterEntity.mov_tp == "" || MasterEntity.mov_tp == null)//when form is blank and we save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Select Movement Type");
                showMessageService.ShowMessage();

                return false;
            }
            else
            {

                if (MasterEntity.mov_tp == "114")
                {
                    if (MasterEntity.order_doc_no == null || MasterEntity.order_doc_no == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Order No");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in GoodsIssueDetails)
                {
                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        int flag = 0; //duplicate entry is allowed so commented : pending delete
                        if (o.id == 0)
                        {
                            foreach (var p in GoodsIssueDetails)
                            {
                                if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.machine_id == p.machine_id)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} and machine {2}", o.ItemCode, o.sku_desc, o.machinecode);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }

                        #region . Parameter Validation .
                        // Validation For All Parameter Values Selected or Not

                        if (o.StockUnt == true && o.id == 0)
                        {
                            var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                            if (paralist.Count > 0)
                            {
                                string[] SkuList = new string[100];           //string array
                                List<string> SkuListt = new List<string>();    // stringlist

                                if (o.sku != null && o.sku != "")
                                {
                                    SkuList = o.sku.Split('/');
                                    SkuListt = SkuList.ToList();

                                    foreach (var item in SkuList)
                                    {
                                        if (item == "")
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Parameter Validation";
                                            showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not. \n ", o.ItemCode, GoodsIssueDetails.IndexOf(o), SkuList.ToList().IndexOf(item));
                                            showMessageService.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, GoodsIssueDetails.IndexOf(o));
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                        }
                        #endregion

                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.store_code == null || o.store_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Store code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();

                        }
                        if (MC.batchList != null && MC.batchList.Count > 0)
                        {
                            var BatchDataItem = MC.batchList.Where(x => x.ItemCode == o.ItemCode && x.location_id == o.location_Id && x.client == o.client && x.store_code == o.store_code).ToList();
                            var BatchDataTab = dgBatchEntity.Where(x => x.ItemCode == o.ItemCode && x.location_Id == o.location_Id && x.client == o.client && x.store_code == o.store_code && string.IsNullOrWhiteSpace(x.batch_no) == false).ToList();
                            if (BatchDataItem.Count > 0 && BatchDataTab.Count == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invalid or Empty Batch Number");
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }

                    }
                    else

                    {

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please select Item ........");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }


                //Validation for Entered Batch Quantity More than Stock Quantity
                for (int a = 0; a < dgBatchEntity.Count; a++)
                {
                    for (int b = 0; b < MC.batchList.Count; b++)
                    {
                        if (dgBatchEntity[a].batch_no == MC.batchList[b].batch_no && dgBatchEntity[a].ItemCode == MC.batchList[b].ItemCode)
                        {
                            if (dgBatchEntity[a].rec_qty > MC.batchList[b].stock_total)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", dgBatchEntity[a].batch_no, dgBatchEntity[a].rec_qty, MC.batchList[b].stock_total);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }
                    }
                }
                //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
                bool breakfor = false;
                for (int i = 0; i < GoodsIssueDetails.Count; i++)
                {
                    decimal temp = 0;
                    int flag = 0;
                    for (int j = 0; j < dgBatchEntity.Count; j++)
                    {
                        if (GoodsIssueDetails[i].line_id == dgBatchEntity[j].sr_line_no)
                        {
                            temp = temp + Convert.ToDecimal(dgBatchEntity[j].qty);
                            flag = 1;
                        }
                    }
                    if (GoodsIssueDetails[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} sku :{1} ", GoodsIssueDetails[i].ItemCode, GoodsIssueDetails[i].sku_desc);
                        showMessageService.ShowMessage();
                        breakfor = false;
                        return false;
                    }
                }
            }

            //foreach (var item in MC.GoodsA)
            //{
            //    if (item.ItemCode == GoodsIssueDetails[dgSelectedIndex].ItemCode)
            //    {
            //        if (GoodsIssueDetails[dgSelectedIndex].qty > item.qty)
            //        {
            //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //            showMessageService.ButtonSetup = DialogButton.Ok;
            //            showMessageService.Caption = "Message";
            //            showMessageService.Text = String.Format("Issue Quantity should not exceed Order Quantiy ");
            //            showMessageService.ShowMessage();
            //            return false;
            //        }
            //    }
            //}

            return true;
        }
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                MasterEntity.XmlDataDocument_MM_T001 = objSer.ObjectToXML(GoodsIssueDetails);
                MasterEntity.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(dgBatchEntity);
                this.MasterEntity.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Issue", "SCM");
                        MoveFlag = false;
                        LockAfterSave = true;

                    }

                    else if (NewRecord == false)
                    {

                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Issue", "SCM");

                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    RemoveRefDoc();
                    parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable
                    _dataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));

                    var msg = new NotificationMessage("MM_T001_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            {


            }


        }
        //private void RemoveRefDoc()
        //{
        //    try
        //    {
        //        var IndentToRemove = MC.IndentOrIndentNoList.SingleOrDefault(s => s.req_no == MasterEntity.ref_doc);
        //        if (IndentToRemove.req_ref != null || IndentToRemove.req_ref != "")
        //        {
        //            MC.IndentOrIndentNoList.Remove(IndentToRemove);

        //            CollectionIndent = CollectionViewSource.GetDefaultView(MC.IndentOrIndentNoList);
        //            CollectionIndent.Filter = new Predicate<object>(FilterIndent);
        //            CollectionIndent.Refresh();

        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_T003_P)x).req_no);
        //            TheFilter = (o, prefix) => ((MM_T003_P)o).req_no.ToLower().Contains(prefix.ToLower());
        //            AS_Indent = new AutoSuggestTextViewModel<dynamic>(MC.IndentOrIndentNoList, TheFilter, SuggestedValue, "ref_doc", "req_no", true);
        //            AS_Indent.AutoSuggestVM.IsEmptyValueAllowed = true;

        //            MasterEntity.ref_doc = null;
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
        private void RemoveRefDoc()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.ref_doc) == false && MC.IndentOrIndentNoList != null)
                {
                    if (MC.IndentOrIndentNoList.Count > 0)
                    {
                        MC.IndentOrIndentNoList.Remove(MC.IndentOrIndentNoList.Single(s => s.req_no == MasterEntity.ref_doc));
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001 != null)
            {
                MC.GoodsA = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001, GoodsIssueDetails);
                GoodsIssueDetails.Clear();
                GoodsIssueDetails = MC.GoodsA;
            }
            else
            {
                MC.GoodsA = new ObservableCollection<MM_T001_A>();
            }

            if (MasterEntity.XmlDataDocument_MM_T001_B != null)
            {
                MC.ItemBatchDetails = (ObservableCollection<MM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_B, dgBatchEntity);
                dgBatchEntity.Clear();
                foreach (MM_T001_A item in GoodsIssueDetails)
                {
                    foreach (MM_T001_B batch in MC.ItemBatchDetails)
                    {
                        if (item.ItemCode == batch.ItemCode && (item.sku ?? "") == (batch.sku ?? ""))
                        {
                            batch.sr_line_no = item.line_id;
                        }
                    }
                }
                dgBatchEntity = MC.ItemBatchDetails;
            }
            else
            {
                MC.ItemBatchDetails = new ObservableCollection<MM_T001_B>();
            }
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<MM_T001Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);

            }

        }
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            NewRecord = true; parameter = false;
            foreach (var listItem in MC.items.ToList())
                listItem.Select = false;

            GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
            GoodsIssueDetails.Clear();
            MoveFlag = true; LockAfterSave = true;
            _dataGridCollection.Refresh();
            MasterEntity = new MM_T001();
            DefaultValues();
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.ValidateAsync().Wait();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();

            var Collection = (from o in MC.OrderDocNoList where o.doc_cat == "ZZ" select o).ToList();
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((Order_No_P)x).order_no);
            TheFilter = (o, prefix) => ((Order_No_P)o).order_no.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
            ASOrder = new AutoSuggestTextViewModel<dynamic>(Collection, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
            ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;
            var msg = new NotificationMessage("MM_T001_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format("This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();
                string response = repository.Delete(MasterEntity.doc_no, "Goods_Issue", "SCM");


                MasterEntity = new MM_T001();

                GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
                GoodsIssueDetails.Clear();
                dgBatchEntity = new ObservableCollection<MM_T001_B>();
                dgBatchEntity.Clear();
                NewRecord = true;
                parameter = false;
                MoveFlag = true;
                LockAfterSave = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {
            FlipGridData = FlipGridData;
        }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
            FlipGridData = FlipGridData;
            MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {
            FlipGridData = FlipGridData;
            MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                string Request = "MaterialIssue" + "!@" + MasterEntity.doc_no;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "Goods_Issue", "SCM", Request, 0, "");

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                objDataSource[0] = MCTemp.RptMaterialIssue;
                objDataSource[1] = MCTemp.RptMaterialIssueItem;
                objDataSource[2] = MCTemp.RptMaterialIssueBatch;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[4] = Result;

                objDataSourceName[0] = "dsDocumentMaster";
                objDataSourceName[1] = "dsGoodsA";
                objDataSourceName[2] = "dsItemBatchDetails";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\MaterialIssue.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion
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
        #region filters

        #region Filters For Requester
        private string _filterStringRequester;
        private void FilterCollectionRequester()
        {
            if (_CollectionRequester != null)
            {
                _CollectionRequester.Refresh();
            }
        }
        public string FilterStringRequester
        {
            get { return _filterStringRequester; }
            set
            {
                _filterStringRequester = value;
                RaisePropertyChanged("FilterStringRequester");
                FilterCollectionRequester();
            }
        }
        public bool Filterrequest(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringRequester))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringRequester.ToLower()) ||
                             data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringRequester.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Department
        private string _filterStringDepartment;
        private void FilterCollectionDepartment()
        {
            if (_CollectionDepartment != null)
            {
                _CollectionDepartment.Refresh();
            }
        }
        public string FilterStringDepartment
        {
            get { return _filterStringDepartment; }
            set
            {
                _filterStringDepartment = value;
                RaisePropertyChanged("FilterStringDepartment");
                FilterCollectionDepartment();
            }
        }
        public bool FilterDept(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDepartment))
                {
                    return (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringDepartment.ToLower()) ||
                            data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringDepartment.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Movement Type
        private string _filterStringMovType;
        private void FilterCollectionMovType()
        {
            if (_CollectionMovType != null)
            {
                _CollectionMovType.Refresh();
            }
        }
        public string FilterStringMovType
        {
            get { return _filterStringMovType; }
            set
            {
                _filterStringMovType = value;
                RaisePropertyChanged("FilterStringMovType");
                FilterCollectionMovType();
            }
        }
        public bool FilterMovType(object obj)
        {
            var data = obj as MM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMovType))
                {
                    return (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterStringMovType.ToLower())) ||
                         (data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_filterStringMovType.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Items
        private string _filterStringItem;
        private void FilterCollectionItem()
        {
            if (_CollectionItem != null)
            {
                _CollectionItem.Refresh();
            }
        }
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterCollectionItem();
            }
        }
        public bool FilterItems(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Unit
        private string _filterStringUnit;
        private void FilterCollectionUnit()
        {
            if (_CollectionUnit != null)
            {
                _CollectionUnit.Refresh();
            }
        }
        public string FilterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                FilterCollectionUnit();
            }
        }
        public bool FilterUnit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower())
                         || data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Company 
        private string _filterStringCompany;

        private void FilterCollectionCompany()
        {
            if (_CollectionCompany != null)
            {
                _CollectionCompany.Refresh();
            }
        }
        public string FilterStringCompany
        {
            get { return _filterStringCompany; }
            set
            {
                _filterStringCompany = value;
                RaisePropertyChanged("FilterStringCompany");
                FilterCollectionCompany();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCompany))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterStringCompany.ToLower()) ||
                         data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterStringCompany.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Plant 
        private string _filterStringPlant_A;

        private void FilterCollectionPlantA()
        {
            if (_CollectionPlant_A != null)
            {
                _CollectionPlant_A.Refresh();
            }
        }
        public string FilterStringPlantA
        {
            get { return _filterStringPlant_A; }
            set
            {
                _filterStringPlant_A = value;
                RaisePropertyChanged("FilterStringPlantA");
                FilterCollectionPlantA();
            }
        }
        public bool FilterPlantA(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant_A))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant_A.ToLower()) ||
                         data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringPlant_A.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Store Location
        private string _filterStringCostCenter;
        private string _filterStringStoreLocation;
        private void FilterCollectionStoreLocation()
        {
            if (_CollectionStoreLocation != null)
            {
                _CollectionStoreLocation.Refresh();
            }
        }
        public string FilterStringStoreLocation
        {
            get { return _filterStringStoreLocation; }
            set
            {
                _filterStringStoreLocation = value;
                RaisePropertyChanged("FilterStringStoreLocation");
                FilterCollectionStoreLocation();
            }
        }
        public bool FilterStoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringStoreLocation))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterStringStoreLocation.ToLower())) ||
                        (data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterStringStoreLocation.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "Filter for Back Content Datagrid"
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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as MM_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.post_date != null && data.post_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.loctaionName != null && data.loctaionName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.ref_doc != null && data.ref_doc.ToString().ToLower().Contains(_filterString.ToLower())
                           );

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For batch
        private string _filterStringbatch;
        private void FilterCollectionbatch()
        {
            if (_batchCollection != null)
            {
                _batchCollection.Refresh();
            }
        }
        public string FilterStringbatch
        {
            get { return _filterStringbatch; }
            set
            {
                _filterStringbatch = value;
                RaisePropertyChanged("FilterStringbatch");
                FilterCollectionbatch();
            }
        }
        public bool Filterbatch(object obj)
        {

            var data = obj as MM_S003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringbatch))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterStringbatch.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #region Filters For MachineCode
        private string _filterStringMachine;
        private void FilterCollectionMachine()
        {
            if (_MachineCodeCollection != null)
            {
                _MachineCodeCollection.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool FilterMachine(object obj)
        {

            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringMachine.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringMachine.ToLower()));

                }
                return true;
            }
            return false;
        }
        //------
        private string _filterStringMachineCode;
        private void FilterCollectionMachineCode()
        {
            if (_MachineCodeCollection != null)
            {
                _MachineCodeCollection.Refresh();
            }
        }
        public string FilterStringMachineCode
        {
            get { return _filterStringMachineCode; }
            set
            {
                _filterStringMachineCode = value;
                RaisePropertyChanged("FilterStringMachineCode");
                FilterCollectionMachineCode();
            }
        }
        public bool FilterMachineCode(object obj)
        {

            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachineCode))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringMachineCode.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringMachineCode.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For orderNo
        private void FilterCollectionOrderDocNo()
        {
            if (_collectionOrderNo != null)
            {
                _collectionOrderNo.Refresh();
            }
        }
        private string _FilterStringOrderDocNo;
        public string FilterStringOrderDocNo
        {
            get { return _FilterStringOrderDocNo; }
            set
            {
                _FilterStringOrderDocNo = value;
                RaisePropertyChanged("FilterStringOrderDocNo");
                FilterCollectionOrderDocNo();
            }
        }
        public bool FilterOrderDocNo(object obj)
        {

            var data = obj as Order_No_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringOrderDocNo))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterStringOrderDocNo.ToLower()) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringOrderDocNo.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterStringOrderDocNo.ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Indent
        private string _filterStringIndent;
        private void FilterCollectionIndent()
        {
            if (_CollectionIndent != null)
            {
                _CollectionIndent.Refresh();
            }
        }
        public string FilterStringIndent
        {
            get { return _filterStringIndent; }
            set
            {
                _filterStringIndent = value;
                RaisePropertyChanged("FilterStringIndent");
                FilterCollectionIndent();
            }
        }
        public bool FilterIndent(object obj)
        {
            var data = obj as MM_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringIndent))
                {
                    return (data.req_no != null && data.req_no.ToString().ToLower().Contains(_filterStringIndent.ToLower()));

                }
                return true;
            }
            return false;
        }


        #endregion

        #endregion
    }

}
