using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_AVM : WorkspaceViewModel<MM_T001>
    {
        #region AutoSuggest Textbox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T001_AVM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        //private DataGridCellInfo _cellInfo;
        //public DataGridCellInfo CellInfo
        //{
        //    get { return _cellInfo; }
        //    set
        //    {
        //        _cellInfo = value;
        //        SetAutoTextSource(_cellInfo);
        //        RaisePropertyChanged("CellInfo");
        //    }
        //}

        //private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        //{
        //    if (dgCellInfo != null)
        //    {
        //        var column = dgCellInfo.Column as DataGridColumn;
        //        if (column != null)
        //        {
        //            string headerName = column.Header.ToString();
        //            string SourceName = column.SortMemberPath.ToString();
        //            if (SourceName == "ItemCode")
        //            { ASDefault = ASItem; }
        //            //else if (SourceName == "defect_type")
        //            //{ ASDefault1 = AS_Defect; }


        //        }
        //    }
        //}

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

        private AutoSuggestTextViewModel<dynamic> _ASMoveType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMoveType
        {
            get { return _ASMoveType; }
            set
            {
                if (_ASMoveType != value)
                {
                    _ASMoveType = value; RaisePropertyChanged("ASMoveType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDept { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDept
        {
            get { return _ASDept; }
            set
            {
                if (_ASDept != value)
                {
                    _ASDept = value; RaisePropertyChanged("ASDept");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRequester { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRequester
        {
            get { return _ASRequester; }
            set
            {
                if (_ASRequester != value)
                {
                    _ASRequester = value; RaisePropertyChanged("ASRequester");
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

        private AutoSuggestTextViewModel<dynamic> _ASstore { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStore
        {
            get { return _ASstore; }
            set
            {
                if (_ASstore != value)
                {
                    _ASstore = value; RaisePropertyChanged("ASstore");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPo
        {
            get { return _ASPo; }
            set
            {
                if (_ASPo != value)
                {
                    _ASPo = value; RaisePropertyChanged("ASPo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPg
        {
            get { return _ASPg; }
            set
            {
                if (_ASPg != value)
                {
                    _ASPg = value; RaisePropertyChanged("ASPg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBatch1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBatch1
        {
            get { return _ASBatch1; }
            set
            {
                if (_ASBatch1 != value)
                {
                    _ASBatch1 = value; RaisePropertyChanged("ASBatch1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRIndent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRIndent
        {
            get { return _ASRIndent; }
            set
            {
                if (_ASRIndent != value)
                {
                    _ASRIndent = value; RaisePropertyChanged("ASRIndent");
                }
            }
        }

        #endregion

        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repositoryM = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MCTemp1 = new WebServiceRepository<BusinessEntity.MC_MM_T001>();
        MC_MM_T001 MCTemp = new MC_MM_T001();
        MC_MM_T001 MCTemp1 = new MC_MM_T001();
        MC_MM_T001 MCIndent = new MC_MM_T001();
        ObjectSerializationService objSer = new ObjectSerializationService();
        private List<ADM_M022_P> _ItemsList = new List<ADM_M022_P>();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

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

        //mov type is not change after save 
        private bool _MoveFlag;
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }
        string store_location;
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

        MC_MM_T001 MCIssueNo = new MC_MM_T001();

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

        private MM_T001_A _ItemDetailsEntity;
        public MM_T001_A ItemDetailsEntity
        {
            get
            {
                return _ItemDetailsEntity;
            }
            set
            {
                if (_ItemDetailsEntity != value)
                {
                    _ItemDetailsEntity = value;
                    RaisePropertyChanged("ItemDetailsEntity");
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
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForSchedule function evry time. which will not work after one time use earlier.
                    //_dgBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("dgBatchEntity");
                }
            }
        }
        private ObservableCollection<MM_T001_B> _ItemBatch_list = new ObservableCollection<MM_T001_B>();

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



        private List<MM_T003_P> _SelectedIssueList;
        public List<MM_T003_P> SelectedIssueList
        {
            get { return _SelectedIssueList; }
            set
            {
                if (_SelectedIssueList != value)
                {
                    _SelectedIssueList = value;
                    RaisePropertyChanged("SelectedIssueList");
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

        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }

        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
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

        #region Validation Region
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;

        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion

        #region ICollection
        private ICollectionView _AttachmentCollection;
        public ICollectionView AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

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

        private ICollectionView _NotificationDataCollection;
        public ICollectionView NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set { _NotificationDataCollection = value; RaisePropertyChanged("NotificationDataCollection"); }
        }


        private ICollectionView _CollectionIssueNo;
        public ICollectionView CollectionIssueNo
        {
            get { return _CollectionIssueNo; }
            set
            {
                _CollectionIssueNo = value;
                RaisePropertyChanged("CollectionIssueNo")
               ;
            }
        }

        private ICollectionView _MachineCodeCollection;
        public ICollectionView MachineCodeCollection
        {
            get { return _MachineCodeCollection; }
            set { _MachineCodeCollection = value; RaisePropertyChanged("MachineCodeCollection"); }
        }
        #region Temp Variables

        private ICollectionView _dataGridview;
        public ICollectionView DataGridView
        {
            get { return _dataGridview; }
            set { _dataGridview = value; RaisePropertyChanged("DataGridView"); }
        }

        #endregion

        private ICollectionView _po_orgCollection;
        public ICollectionView po_orgCollection
        {
            get { return _po_orgCollection; }
            set
            {
                _po_orgCollection = value;
                RaisePropertyChanged("po_orgCollection");
            }
        }
        private ICollectionView _pur_groupCollection;
        public ICollectionView Purchase_groupCollection
        {
            get { return _pur_groupCollection; }
            set
            {
                _pur_groupCollection = value;
                RaisePropertyChanged("Purchase_groupCollection");
            }
        }

        private ICollectionView _BatchCollection;
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set
            {
                _BatchCollection = value;
                RaisePropertyChanged("BatchCollection");
            }
        }
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
                }
            }
        }

        List<string> _strListPurchaseOrg;
        public List<string> StringListPurchaseOrg
        {
            get { return _strListPurchaseOrg; }
            set
            {
                if (_strListPurchaseOrg != value)
                {
                    _strListPurchaseOrg = value;
                }
            }
        }

        List<string> _strListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _strListPurchaseGroup; }
            set
            {
                if (_strListPurchaseGroup != value)
                {
                    _strListPurchaseGroup = value;
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
        public RelayCommand<object> CommandPurchaseOrg { get; private set; }
        public RelayCommand<object> CommandPurchaseGroup { get; private set; }

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
        public RelayCommand<IList> BatchCollectionChangeCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> SelectionChangedCommandBarcode
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandbatch
        {
            get;
            private set;
        }
        public RelayCommand<object> batch_EditingCommand
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
        public RelayCommand<object> SelectionChangedCommandIssueNo
        {
            get;
            private set;
        }
        public RelayCommand<IList> batchSelectionCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<IList> SelectionChangedCommandGoodsIssueDetails
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandLoadIssueDetails
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
        public RelayCommand<object> SelectionChangedBatchDetailsCommand//clik 
        {
            get;
            private set;
        }
        public RelayCommand<object> ActiveInActiveChangeCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandMachine { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadRecords { get; private set; }
        public RelayCommand<object> CMDLoadReturnIndent { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CMDLoadRindent { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
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
        public MM_T001_AVM(string ts_code)
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
            MCTemp1 = new MC_MM_T001();
            MC = new MC_MM_T001();
            SelectedItemList = new List<ADM_M022_P>();
            SelectedIssueList = new List<MM_T003_P>();
            MasterEntity.ValidateAsync().Wait();
            MoveFlag = true;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;

            LoadInitialData();

            //if (AppSessionState.TransValue != null)
            //{
            //    LoadDocumentByDocumentNumber(AppSessionState.TransValue);
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }

        public MM_T001_AVM(string ts_code, string doc_no)
            : base()
        {
            parameter = false;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new MM_T001();
            FlipGridData = new List<MM_T001Flip>();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MM_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
            MC.GoodsA = new ObservableCollection<MM_T001_A>();
            MCTemp1 = new MC_MM_T001();
            MC = new MC_MM_T001();
            SelectedItemList = new List<ADM_M022_P>();
            SelectedIssueList = new List<MM_T003_P>();
            MasterEntity.ValidateAsync().Wait();
            MoveFlag = true;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;

            LoadInitialData();

            //if (AppSessionState.TransValue != null)
            //{
            //    LoadDocumentByDocumentNumber(AppSessionState.TransValue);
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        #endregion

        #region . User Defined Function.
        private void LoadDocumentByDocumentNumber(object ParameterObject)
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
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.ref_doc; }
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
                            MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Receipt", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                            if (ParametersStringValue == "ReferenceDocument")
                            {
                                MasterEntity.ref_doc = MasterEntity.doc_no;
                                MasterEntity.ref_doc_date = MasterEntity.doc_date;
                                MasterEntity.doc_cat = "MR";
                                MasterEntity.doc_type = "MR";
                                MasterEntity.doc_no = null;
                                MasterEntity.mov_tp = null;
                                MasterEntity.mov_name = null;
                                MasterEntity.doc_date = DateTime.Now;
                                MasterEntity.post_date = DateTime.Now;
                                MasterEntity.add_by = AppSessionState.UserID;
                                MasterEntity.editby = AppSessionState.UserID;
                                MasterEntity.active = true;
                                MasterEntity.t_status = "001";
                                MasterEntity.client = AppSessionState.client;
                                MasterEntity.mov_tp = "124";
                                MasterEntity.mov_name = "Goods Receipt  From Production";
                                MasterEntity.ts_code = ts_code_vm;

                            }
                        }

                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                        NewRecord = false;
                        MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Receipt", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                        AttachmentCollection = CollectionViewSource.GetDefaultView(MC.Attachment);
                        MoveFlag = false;
                        //MasterEntity.ts_code = ts_code_vm;
                    }
                }


                MasterEntity.ts_code = ts_code_vm;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                parameter = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("MM_T001_AVM");
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
        private void LoadIssueDetails(object items)
        {
            try
            {

                string Request = "LoadIssueNodetails" + "!@" + MasterEntity.ref_doc;
                MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Receipt", "SCM", "LoadIssueNodetails", 0, "");

                DefaultValues();
                if (MasterEntity.XmlDataDocument_MM_T001 != null)
                {
                    MC.GoodsA = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001, MC.GoodsA);
                    GoodsIssueDetails = MC.GoodsA;
                }
                else
                {
                    MC.GoodsA = new ObservableCollection<MM_T001_A>();
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
        private void InsertReturnIndent(object InputValue)
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
                            { POPUPEntityObject = MC.ReturnIndentNo.Where(x => x.req_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_T003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc = POPUPEntityObject.req_no;
                    MasterEntity.source_doc_cat = POPUPEntityObject.req_ref;
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
        private void LoadIndentOrder()
        {
            try
            {
                string Request = "";
                if (MasterEntity.source_doc_cat == "OR")
                {
                    Request = "LoadProductionOrder" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.ref_doc;
                }
                else
                {
                    Request = "LoadReturnIndent" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.ref_doc;
                }

                MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp1, Request, "Goods_Receipt", "SCM", Request, 0, "LoadInitialData");

                if (MCTemp1.DocumentMaster.Count > 0)
                {
                    MasterEntity = MCTemp1.DocumentMaster[0];
                    GoodsIssueDetails = MCTemp1.GoodsA;
                    dgBatchEntity = MCTemp1.ItemBatchDetails;
                    foreach (var item in GoodsIssueDetails)
                    {
                        foreach (var batch in dgBatchEntity)
                        {
                            if (item.barcode == batch.barcode && item.confirmation_no == batch.confirmation_no)
                            {
                                batch.sr_line_no = item.line_id;
                                batch.confirmation_no = item.confirmation_no;
                            }
                        }
                    }
                    MasterEntity.post_date = DateTime.Now;
                    DefaultValues();
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
            var msg = new NotificationMessage("MM_T001_AVM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertPurchaseOrg(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_M_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseOrganisationList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
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
        private void InsertPurchaseGroup(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseGroupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
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
        private void GetSelectedIndentDetails(IList IndentNoList)//indent no selection
        {

            IList list = IndentNoList as IList;
            List<MM_T003_P> GetSelectedIndentDetailsTemp = list.Cast<MM_T003_P>().ToList();

            if (GetSelectedIndentDetailsTemp.Count > 0)
            {
                MasterEntity.ref_doc = GetSelectedIndentDetailsTemp[0].req_no;
            }

        }
        private void LoadInitialData()
        {
            try
            {

                MasterEntity.doc_cat = "MR";
                MasterEntity.doc_type = "MR";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + AppSessionState.client;
                MC = repositoryM.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "Goods_Receipt", "SCM", Request, 0, "LoadInitialData");

                #region Command Initialisation
                SelectionChangedCommandRequester = new RelayCommand<object>(items => { if (items == null) { return; } InsertRequster(items); });
                SelectionChangedCommandDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeptment(items); });
                SelectionChangedCommandMovType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                CommandPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                CommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                SelectionChangedCommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                SelectionChangedCommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Uom(cmdPara, false, true, true); });
                SelectionChangedCommandStoreLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });
                SelectionChangedCommandPlantA = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Plant(cmdPara, false, true, true); });
                SelectionChangedCommandbatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Batch(cmdPara, false, true, true); });
                SelectionChangedBatchDetailsCommand = new RelayCommand<object>(Items => { if (Items == null) { return; } GetSelectedBatchForItem(Items, true, false, true); });
                BatchCollectionChangeCommand = new RelayCommand<IList>(Items => { if (Items == null) { return; } GetBatchCollection(Items); }); // used for batch popup on batch details tab
                SelectionChangedCommandBarcode = new RelayCommand<string>(Items => { if (Items == null) { return; } GetBatchbyBarcode(Items); });  // For Barcode Reading                                                                                                                                  //batchSelectionCommand = new RelayCommand<IList>(items => { if (items == null) { return; }  batchSelection(items); });
                SelectionChangedCommandLoadIssueDetails = new RelayCommand<object>(items => { if (items == null) { return; } LoadIssueDetails(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                DataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                DataGridRowDeleteCommandBatch = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_ItemBatch(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
                SelectionChangedCommandMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_MachineCode(cmdPara, false, true, true); });
                cmdLoadRecords = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadRecords(); });
                CMDLoadReturnIndent = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReturnIndent(cmdPara); });
                CMDLoadRindent = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadIndentOrder(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                #region Auto Suggest Initalization Region

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M004_P)x).mov_tp);
                TheFilter = (o, prefix) => ((MM_M004_P)o).mov_tp.ToLower().Contains(prefix.ToLower()) || ((MM_M004_P)o).mov_tp_name.ToLower().Contains(prefix.ToLower());
                ASMoveType = new AutoSuggestTextViewModel<dynamic>(MC.MovementTypeList, TheFilter, SuggestedValue, "mov_tp", true);
                ASMoveType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code);
                TheFilter = (o, prefix) => ((ADM_M025_P)o).dept_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M025_P)o).DeptName.ToLower().Contains(prefix.ToLower());
                ASDept = new AutoSuggestTextViewModel<dynamic>(MC.deptList, TheFilter, SuggestedValue, "dept_code", true);
                ASDept.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToLower().Contains(prefix.ToLower()) || ((ADM_M024_P)o).EmpName.ToLower().Contains(prefix.ToLower());
                ASRequester = new AutoSuggestTextViewModel<dynamic>(MC.Requster, TheFilter, SuggestedValue, "EmpId", true);
                ASRequester.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.ToLower().Contains(prefix.ToLower()) || ((ADM_M022_P)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.items, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.ToLower().Contains(prefix.ToLower()) || ((ADM_M022_P)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.items, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.unitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T003_A_P)x).batch_no);
                TheFilter = (o, prefix) => (((EPR_T003_A_P)o).batch_no ?? "").ToLower().Contains(prefix.ToLower());
                ASBatch = new AutoSuggestTextViewModel<dynamic>(MC.CartonsList, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                ASBatch.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                store_location = (from o in store_temp_list
                                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
                if (store_temp_list.Count == 1)
                {
                    store_location = store_temp_list[0].store_code;
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T003_A_P)x).batch_no);
                TheFilter = (o, prefix) => (((EPR_T003_A_P)o).batch_no ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.CartonsList, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T003_A_P)x).batch_no);
                TheFilter = (o, prefix) => (((EPR_T003_A_P)o).batch_no ?? "").ToLower().Contains(prefix.ToLower());
                ASBatch1 = new AutoSuggestTextViewModel<dynamic>(MC.CartonsList, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                ASBatch1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_T003_P)x).req_no);
                TheFilter = (o, prefix) => ((MM_T003_P)o).req_no.ToLower().Contains(prefix.ToLower());
                ASRIndent = new AutoSuggestTextViewModel<dynamic>(MC.ReturnIndentNo, TheFilter, SuggestedValue, "req_no", true);
                ASRIndent.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();

                NotificationDataCollection = CollectionViewSource.GetDefaultView(MC.NotificationData);

                MasterEntity.post_date = DateTime.Now;

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => ((ADM_M001_M_P)o).po_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M001_M_P)o).pur_org.ToLower().Contains(prefix.ToLower());
                ASPo = new AutoSuggestTextViewModel<dynamic>(PurchaseOrganisationList, TheFilter, SuggestedValue, "po_code", "po_code", true);
                ASPo.AutoSuggestVM.IsEmptyValueAllowed = true;

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }

                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => ((ADM_M001_P_P)o).pg_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M001_P_P)o).pg_name.ToLower().Contains(prefix.ToLower());
                ASPg = new AutoSuggestTextViewModel<dynamic>(PurchaseGroupList, TheFilter, SuggestedValue, "pg_code", "pg_code", true);
                ASPg.AutoSuggestVM.IsEmptyValueAllowed = true;

                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }


                #endregion

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
                StringListItems = MC.items.Select(x => x.ItemCode).ToList();
                CollectionItem.Filter = new Predicate<object>(FilterItems);

                CollectionUnit = CollectionViewSource.GetDefaultView(MC.unitList);
                CollectionUnit.Filter = new Predicate<object>(FilterUnit);
                StringListUOM = MC.unitList.Select(x => x.unit_code).ToList();

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                CollectionPlant_A = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                CollectionPlant_A.Filter = new Predicate<object>(FilterPlantA);
                stringListPlant = ObjSupply.Select(x => x.location_Id).ToList();

                store_temp_list = (List<MM_M001>)AppSessionState.store_location;
                CollectionStoreLocation = CollectionViewSource.GetDefaultView(store_temp_list);
                CollectionStoreLocation.Filter = new Predicate<object>(FilterStoreLoc);
                store_location = (from o in store_temp_list
                                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
                stringListStoreLoc = store_temp_list.Select(x => x.store_code).ToList();
                if (store_temp_list.Count == 1)
                {
                    store_location = store_temp_list[0].store_code;
                }

                DefaultValues();

                NotificationDataCollection = CollectionViewSource.GetDefaultView(MC.NotificationData);

                MasterEntity.post_date = DateTime.Now;

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                po_orgCollection = CollectionViewSource.GetDefaultView(PurchaseOrganisationList);
                po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = PurchaseOrganisationList.Select(x => x.po_code).ToList();

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }

                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                Purchase_groupCollection = CollectionViewSource.GetDefaultView(PurchaseGroupList);
                Purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = PurchaseGroupList.Select(x => x.pg_code).ToList();

                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }

                BatchCollection = CollectionViewSource.GetDefaultView(MC.CartonsList.ToList());
                BatchCollection.Filter = new Predicate<object>(BatchFilter);
                stringListBatch = MC.CartonsList.Select(x => x.batch_no).ToList();

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

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && GoodsIssueDetails.Count == dgSelectedIndex)
                    {

                        GoodsIssueDetails.Add(new MM_T001_A()
                        {

                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            unit_code = POPUPEntityObject.unit_code,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            //posting_period = "1",
                            //fin_year = "15-16",
                            line_id = GoodsIssueDetails.Count + 1,
                            active = true,
                            store_code = store_location,
                            debcr_ind = "C",
                            mat_con = "New"
                        });

                    }

                    else if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            GoodsIssueDetails[dgSelectedIndex].ItemCode = POPUPEntityObject.ItemCode;
                            GoodsIssueDetails[dgSelectedIndex].description = POPUPEntityObject.ItemName;
                            GoodsIssueDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            GoodsIssueDetails[dgSelectedIndex].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                            GoodsIssueDetails[dgSelectedIndex].active = true;
                            GoodsIssueDetails[dgSelectedIndex].SubCatCode = POPUPEntityObject.SubCatCode;
                            GoodsIssueDetails[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            GoodsIssueDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            //GoodsIssueDetails[dgSelectedIndex].fin_year = "15-16";
                            //GoodsIssueDetails[dgSelectedIndex].posting_period = "1";
                            GoodsIssueDetails[dgSelectedIndex].line_id = 0;
                            GoodsIssueDetails[dgSelectedIndex].store_code = store_location;
                            GoodsIssueDetails[dgSelectedIndex].qty = POPUPEntityObject.qty;
                            GoodsIssueDetails[dgSelectedIndex].active = true;
                            GoodsIssueDetails[dgSelectedIndex].mat_con = "New";
                            GoodsIssueDetails[dgSelectedIndex].client = AppSessionState.client;
                        }

                        else if (GoodsIssueDetails[dgSelectedIndex].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            GoodsIssueDetails[dgSelectedIndex].ItemCode = "";
                            GoodsIssueDetails[dgSelectedIndex].description = "";
                        }
                    }
                }

                if (MC.MachineCodeList.Count > 0 && dgSelectedIndex > 0 && GoodsIssueDetails.Count > 0)
                {
                    MachineCode_temp_list = (from o in MC.MachineCodeList
                                             where o.location_Id == GoodsIssueDetails[dgSelectedIndex - 1].location_Id
                                             select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                    TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.ToLower().Contains(prefix);
                    ASMachine = new AutoSuggestTextViewModel<dynamic>(MachineCode_temp_list, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                    ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;

                    //MachineCodeCollection = CollectionViewSource.GetDefaultView(MachineCode_temp_list);
                    //MachineCodeCollection.Filter = new Predicate<object>(FilterMachineCode);
                    //StringListMachineCode = MachineCode_temp_list.Select(x => x.machinecode).ToList();
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
                        GoodsIssueDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
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
                            GoodsIssueDetails[dgSelectedIndex].machinecode = "";
                            //MachineCode_temp_list = (from o in MC.MachineCodeList
                            //                         where o.location_Id == POPUPEntityObject.location_Id
                            //                         select o).ToList();
                            //MachineCodeCollection = CollectionViewSource.GetDefaultView(MachineCode_temp_list);
                            //StringListMachineCode = MachineCode_temp_list.Select(x => x.machinecode).ToList();
                            //MachineCodeCollection.Filter = new Predicate<object>(FilterMachineCode);

                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].location_Id != POPUPEntityObject.location_Id)
                        {
                            GoodsIssueDetails[dgSelectedIndex].location_Id = "";
                        }
                    }
                }
                if (MC.MachineCodeList.Count > 0 && dgSelectedIndex >= 0 && GoodsIssueDetails.Count > 0)
                {

                    MachineCode_temp_list = (from o in MC.MachineCodeList
                                             where o.location_Id == GoodsIssueDetails[dgSelectedIndex].location_Id
                                             select o).ToList();
                    MachineCodeCollection = CollectionViewSource.GetDefaultView(MachineCode_temp_list);
                    MachineCodeCollection.Filter = new Predicate<object>(FilterMachineCode);
                    StringListMachineCode = MachineCode_temp_list.Select(x => x.machinecode).ToList();
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
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].store_code != POPUPEntityObject.store_code)
                        {
                            GoodsIssueDetails[dgSelectedIndex].store_code = "";
                        }
                    }
                    if (dgBatchEntity != null)
                    {
                        if (dgBatchEntity.Count > 0)
                        {
                            foreach (var item in dgBatchEntity)
                            {
                                item.store_code = POPUPEntityObject.store_code;
                            }
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
                            BatchDetails = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; BatchDetails.Select = true;

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
                    var InputValueIfExists = dgBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgBatchEntity.IndexOf(dgBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault()); // Prefer Primary Key for this instruction.


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
                            qty = BatchDetails.stock_total,
                            rec_qty = BatchDetails.stock_total,
                            comp_code = AppSessionState.comp_code,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            item_line_id = 0,
                            sku = BatchDetails.sku,
                            active = true,
                            //fin_year = "15-16",
                            //posting_period = "1"
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
                            dgBatchEntity[dgSelectedBatchindex].qty = BatchDetails.stock_total;
                            dgBatchEntity[dgSelectedBatchindex].rec_qty = BatchDetails.stock_total;
                            dgBatchEntity[dgSelectedBatchindex].comp_code = AppSessionState.comp_code;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = AppSessionState.location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = BatchDetails.sku;
                            dgBatchEntity[dgSelectedBatchindex].active = true;
                            //dgBatchEntity[dgSelectedBatchindex].fin_year = "15-16";
                            //dgBatchEntity[dgSelectedBatchindex].posting_period = "1";
                        }
                        else if (dgBatchEntity[dgSelectedBatchindex].batch_no != BatchDetails.batch_no)
                        {
                            dgBatchEntity[dgSelectedBatchindex].batch_no = "";
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
        //private void batchSelection(IList batchlist)
        //{
        //    try
        //    {

        //        IList list = batchlist as IList;

        //        if (GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
        //        {

        //            List<MM_T001_A> selectionbatch = list.Cast<MM_T001_A>().ToList();
        //            if (selectionbatch.Count > 0 && dgSelectedIndex != -1)
        //            {


        //                var temp = (from o in MC.batchList
        //                            where o.ItemCode == selectionbatch[0].ItemCode && o.sku == selectionbatch[0].sku
        //                            select o);
        //                batchCollection = CollectionViewSource.GetDefaultView(temp.ToList());
        //                batchCollection.Filter = new Predicate<object>(Filterbatch);
        //                stringListBatch = MC.batchList.Select(x => x.batch_no).ToList();

        //                if (GoodsIssueDetails[dgSelectedIndex].id == 0 && GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
        //                {
        //                    parameter = true;
        //                }
        //                else
        //                {
        //                    parameter = false;
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

        //}
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm);
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
        private void GetBatchCollection(IList BatchList) // get batch collection by selected index Item Details
        {

            IList list = BatchList as IList;
            try
            {
                if (dgSelectedIndex != -1 && GoodsIssueDetails.Count > 0 && GoodsIssueDetails.Count > dgSelectedIndex)
                {
                    List<MM_T001_A> SelectedBatchlist = list.Cast<MM_T001_A>().ToList();

                    if (SelectedBatchlist.Count > 0)
                    {
                        var BatchTemp = (from o in MC.CartonsList where o.ItemCode == SelectedBatchlist[0].ItemCode && o.sku == SelectedBatchlist[0].sku select o).ToList();

                        BatchCollection = CollectionViewSource.GetDefaultView(BatchTemp.ToList());
                        BatchCollection.Refresh();

                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
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
        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        private void FilterBatchDataGrid()
        {
            try
            {
                if (dgBatchEntity != null && dgBatchEntity.Count > 0 && dgSelectedIndex >= 0 && GoodsIssueDetails != null && GoodsIssueDetails.Count > 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(dgBatchEntity);
                    DataGridView.Filter = adv => ((MM_T001_B)adv).sr_line_no.Equals(GoodsIssueDetails[dgSelectedIndex].line_id);
                    DataGridView.Refresh();
                }
            }
            catch { }
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
                            POPUPEntityObject = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                                        qty = POPUPEntityObject.stock_total,
                                        rec_qty = POPUPEntityObject.stock_total,
                                        comp_code = AppSessionState.comp_code,
                                        location_Id = AppSessionState.location_Id,
                                        add_by = AppSessionState.UserID,
                                        sku = POPUPEntityObject.sku,
                                        //posting_period = "1",
                                        //fin_year = "15-16",
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
                                    dgBatchEntity[IndexOfrecord].qty = POPUPEntityObject.stock_total;
                                    dgBatchEntity[IndexOfrecord].rec_qty = POPUPEntityObject.stock_total;
                                    dgBatchEntity[IndexOfrecord].comp_code = AppSessionState.comp_code;
                                    dgBatchEntity[IndexOfrecord].location_Id = AppSessionState.location_Id;
                                    dgBatchEntity[IndexOfrecord].add_by = AppSessionState.UserID;
                                    dgBatchEntity[IndexOfrecord].sku = POPUPEntityObject.sku;
                                    dgBatchEntity[IndexOfrecord].active = true;
                                    //dgBatchEntity[dgSelectedIndex].fin_year = "15-16";
                                    //dgBatchEntity[dgSelectedIndex].posting_period = "1";
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
                                    // ItemCode = SelectedRowlist[0].ItemCode,
                                    dgselectedindex = dgSelectedIndex,
                                    //  value_code = SelectedParaValueList[0].value_code,
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

                    if (GoodsIssueDetails[dgSelectedIndex].id == 0)// && exist == true)
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
        private void CalculateSku() // DT:04062023
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

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (GoodsIssueDetails.Count > i && GoodsIssueDetails[dgSelectedIndex].id == 0)
                {
                    for (int j = dgBatchEntity.Count - 1; j >= 0; j--)
                    {
                        if (GoodsIssueDetails[i].line_id == dgBatchEntity[j].sr_line_no)
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
        private void GetBatchbyBarcode(string InputValue)
        {
            try
            {
                EPR_T003_A_P POPUPEntityObject = null;
                barcode = InputValue.ToString();

                if (barcode.Length > 9)
                {
                    var InputValueIfExists = MC.CartonsList.Where(X => X.barcode == barcode).FirstOrDefault();  //Checking Weather Barcode is Valid or Not By Checking in Business Entity

                    if (InputValueIfExists != null)
                    {
                        POPUPEntityObject = MC.CartonsList.Where(x => x.barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject

                        if (POPUPEntityObject != null)
                        {
                            if (POPUPEntityObject.carton_used_Flg != true)
                            {
                                // checking weather item exist in item details or not

                                int itemexist = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku && X.active == true).FirstOrDefault());

                                if (itemexist != -1)
                                {
                                    int IndexOfExistBatch = dgBatchEntity.IndexOf(dgBatchEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.active == true).FirstOrDefault());

                                    if (IndexOfExistBatch == -1)
                                    {
                                        dgBatchEntity.Add(new MM_T001_B()
                                        {
                                            ItemCode = POPUPEntityObject.ItemName,
                                            sku = POPUPEntityObject.sku,
                                            description = POPUPEntityObject.ItemName,
                                            //sku pending
                                            //barcode = POPUPEntityObject.barcode,
                                            //pack_no = POPUPEntityObject.doc_no,
                                            batch_no = POPUPEntityObject.batch_no,
                                            rec_qty = POPUPEntityObject.tot_qty,
                                            qty = POPUPEntityObject.tot_qty,
                                            unit_code = POPUPEntityObject.unit_code,
                                            location_Id = AppSessionState.location_Id,
                                            comp_code = AppSessionState.comp_code,
                                            active = true,
                                            add_by = AppSessionState.UserID,
                                            editby = AppSessionState.UserID,
                                            fin_year = "16-17",
                                            //posting_period = "7",
                                            //store_code = store_location

                                        });
                                        barcode = "";
                                    }
                                    else
                                    {
                                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                        showMessageService.ButtonSetup = DialogButton.Ok;
                                        showMessageService.Caption = "Message";
                                        showMessageService.Text = String.Format("This Batch/Barcode/Carton Scanned already Exist in Batch Details", this.Title);
                                        showMessageService.ShowMessage();

                                        if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                        {
                                            barcode = "";
                                        }
                                    }
                                }
                                else
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Item of the batch you are scanning does not exist in item details ", this.Title);
                                    showMessageService.ShowMessage();

                                    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                    {
                                        barcode = "";
                                    }
                                }

                            }
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
                showMessageService.ShowMessage(); barcode = InputValue.ToString();
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
                string Request = "LoadRecordsofSelectedDate" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + "MR" + "!@" + Convert.ToDateTime(FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MM_T001>(MCTemp, Request, "Goods_Receipt", "SCM", "LoadRecordsofSelectedDate", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Refresh();

            }
        }
        #endregion

        #region · Command Actions ·

        private void DefaultValues()
        {
            MasterEntity.doc_cat = "MR";
            MasterEntity.doc_code = "MR";
            MasterEntity.doc_type = "MR";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.doc_date = DateTime.Now.Date;
            MasterEntity.vendor = null;
            MasterEntity.PartyId = null;
            MasterEntity.doc_date = DateTime.Now;
            //MasterEntity.fin_year = "15-16";
            //MasterEntity.posting_period = "1";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;

        }

        private bool Validation()
        {
            //if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Organization Code (PO Code) in Org Data Tab");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Group Code (PG Code) in Org Data Tab");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            if (GoodsIssueDetails.Count < 1)//when form is blank and we save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Insert Record........");
                showMessageService.ShowMessage();

                return false;
            }
            else
            {
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in GoodsIssueDetails)
                {
                    if (o.line_id != 0)
                    {
                        int flag = 0;
                        if (o.id == 0)
                        {
                            foreach (var p in GoodsIssueDetails)
                            {
                                if (o.line_id == p.line_id)
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
                            return false;
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
                        if (dgBatchEntity[a].batch_no == MC.batchList[b].batch_no)
                        {
                            if (dgBatchEntity[a].qty > MC.batchList[b].stock_total)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", dgBatchEntity[a].batch_no, dgBatchEntity[a].qty, MC.batchList[b].stock_total);
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

            return true;
        }

        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.XmlDataDocument_MM_T001 = objSer.ObjectToXML(GoodsIssueDetails);
            MasterEntity.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(dgBatchEntity);
            this.MasterEntity.EndEdit();

            if (Validation() == true)
            {
                if (NewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Receipt", "SCM");

                    MoveFlag = false;
                }

                else if (NewRecord == false)
                {

                    MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Receipt", "SCM");

                }

                SetBusinessEntitiesAfterLoad("Save", "");
                NewRecord = false;
                parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable
                _dataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));

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
            dgBatchEntity = new ObservableCollection<MM_T001_B>();
            MoveFlag = true;
            GoodsIssueDetails.Clear();
            _dataGridCollection.Refresh();
            MasterEntity = new MM_T001();
            DefaultValues();
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.post_date = DateTime.Now;

        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();

                string response = repository.Delete(MasterEntity.doc_no, "Goods_Receipt", "SCM");

                _dataGridCollection.Refresh();
                MasterEntity = new MM_T001();

                GoodsIssueDetails = new ObservableCollection<MM_T001_A>();
                GoodsIssueDetails.Clear();
                dgBatchEntity = new ObservableCollection<MM_T001_B>();
                dgBatchEntity.Clear();
                NewRecord = true;
                parameter = false; MoveFlag = true;
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
                string Request = "MaterialReceipt" + "!@" + MasterEntity.doc_no;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "Goods_Receipt", "SCM", Request, 0, "");

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
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\MaterialReceipt.rdlc", getParametersList(), "");
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
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterStringStoreLocation.ToLower()));
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
        #region Batch Filter
        private void FilterCollectionBatch()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        private string _filterString_Batch;
        public string FilterString_Batch
        {
            get { return _filterString_Batch; }
            set
            {
                _filterString_Batch = value;
                RaisePropertyChanged("FilterString_Batch");
                FilterCollectionBatch();
            }
        }
        public bool BatchFilter(object obj)
        {
            var data = obj as EPR_T003_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Batch))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_Batch.ToLower()) ||
                        data.Ink != null && data.Ink.ToString().ToLower().Contains(_filterString_Batch.ToLower()) ||
                        data.Ild != null && data.Ild.ToString().ToLower().Contains(_filterString_Batch.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Batch.ToLower()) ||
                        data.tot_qty != null && data.tot_qty.ToString().ToLower().Contains(_filterString_Batch.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For IssueNo
        private void FilterCollectionIssueNo()
        {
            if (_CollectionIssueNo != null)
            {
                _CollectionIssueNo.Refresh();
            }
        }
        private string _FilterStringIssueNO;
        public string FilterStringIssueNO
        {
            get { return _FilterStringIssueNO; }
            set
            {
                _FilterStringIssueNO = value;
                RaisePropertyChanged("FilterStringIssueNO");
                FilterCollectionIssueNo();
            }
        }
        public bool FilterIssueNo(object obj)
        {
            var data = obj as MM_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringIssueNO))
                {
                    return (data.req_no != null && data.req_no.ToString().ToLower().Contains(_FilterStringIssueNO.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filter For Machine
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
        #region Filter for PO Code
        private string _filterString_PurOrg;
        public string FilterString_PurOrg
        {
            get { return _filterString_PurOrg; }
            set
            {
                _filterString_PurOrg = value;
                RaisePropertyChanged("FilterString_PurOrg");
                FilterCollection_PurOrg();
            }
        }
        private void FilterCollection_PurOrg()
        {
            if (po_orgCollection != null)
            {
                po_orgCollection.Refresh();
            }
        }
        public bool Purorg_Filter(object obj)
        {
            var data = obj as ADM_M001_M_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PurOrg))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_PurOrg.ToLower())) ||
                       (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_PurOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filter for PG Code
        private string _filterString_pur_grp;
        public string FilterString_pur_grp
        {
            get { return _filterString_pur_grp; }
            set
            {
                _filterString_pur_grp = value;
                RaisePropertyChanged("FilterString_pur_grp");
                FilterCollection_pur_grp();
            }
        }
        private void FilterCollection_pur_grp()
        {
            if (Purchase_groupCollection != null)
            {
                Purchase_groupCollection.Refresh();
            }
        }
        public bool Purchase_grp_Filter(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_pur_grp))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_pur_grp.ToLower())) ||
                        (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_pur_grp.ToLower()));
                }
                return true;
            }
            return false;
        }

       
        #endregion
        #endregion
    }
}
