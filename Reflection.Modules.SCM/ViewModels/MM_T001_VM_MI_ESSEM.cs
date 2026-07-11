using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;

namespace Reflection.Modules.SCM.ViewModels
{
    class MM_T001_VM_MI_ESSEM : WorkspaceViewModel<MM_T001>
    {
        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repositoryM = new WebServiceRepository<MC_MM_T001>();
        MC_MM_T001 _MCTemp = new MC_MM_T001();
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
        string store_location;

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
        //mov type is not change after save 
        private bool _MoveFlag;
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private string _MasterMake;
        public string MasterMake
        {
            get { return _MasterMake; }
            set { _MasterMake = value; RaisePropertyChanged("MasterMake"); }
        }

        private string _MasterMatCon;
        public string MasterMatCon
        {
            get { return _MasterMatCon; }
            set { _MasterMatCon = value; RaisePropertyChanged("MasterMatCon"); }
        }
        //private string _MasterType;
        //public string MasterType
        //{
        //    get { return _MasterType; }
        //    set { _MasterType = value; RaisePropertyChanged("MasterType"); }
        //}
        private decimal _TotalQty;
        public decimal TotalQty
        {
            get
            {
                return _TotalQty;
            }
            set
            {
                if (_TotalQty != value)
                {
                    _TotalQty = value;
                    RaisePropertyChanged("TotalQty");
                }
            }
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
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForSchedule function evry time. which will not work after one time use earlier.
                    // _dgBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
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

        private string _Make;
        public string Make
        {
            get { return _Make; }
            set { _Make = value; RaisePropertyChanged("Make"); }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertyChanged("Type"); }
        }

        private string _MaterialCondtion;
        public string MaterialCondtion
        {
            get { return _MaterialCondtion; }
            set { _MaterialCondtion = value; RaisePropertyChanged("MaterialCondtion"); }
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

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _MatConditionCollection;
        public ICollectionView MatConditionCollection
        {
            get { return _MatConditionCollection; }
            set { _MatConditionCollection = value; RaisePropertyChanged("MatConditionCollection"); }
        }

        private ICollectionView _SearchItemsCollection;
        public ICollectionView SearchItemsCollection
        {
            get { return _SearchItemsCollection; }
            set { _SearchItemsCollection = value; RaisePropertyChanged("SearchItemsCollection"); }
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

        List<string> _strListMake;
        public List<string> StringListMake
        {
            get { return _strListMake; }
            set
            {
                if (_strListMake != value)
                {
                    _strListMake = value;
                    RaisePropertyChanged("StringListMake");
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
        public RelayCommand<IList> cmdMake { get; private set; }
        public RelayCommand<object> cmdMasterMake { get; private set; }
        public RelayCommand cmdLoadRecords { get; private set; }
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
        public MM_T001_VM_MI_ESSEM(string ts_code)
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
            TotalQty = 0;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;

            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            GoodsIssueDetails.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            MasterEntity.ValidateAsync().Wait();
            SelectedIndentList = new List<MM_T003_P>();


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
        public MM_T001_VM_MI_ESSEM(string ts_code, string doc_no)
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

            MC = new MC_MM_T001();
            SelectedItemList = new List<ADM_M022_P>();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();
            MoveFlag = true;
            TotalQty = 0;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;

            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            GoodsIssueDetails.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            MasterEntity.ValidateAsync().Wait();
            SelectedIndentList = new List<MM_T003_P>();


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
        private void LoadRecords()
        {
            try
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
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertMasterMake(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterMake = POPUPEntityObject.parametervalue;
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
                            //BatchDetails = dgBatchEntity.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; BatchDetails.Select = true;
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
                            dgBatchEntity[dgSelectedBatchindex].qty = BatchDetails.stock_total;
                            dgBatchEntity[dgSelectedBatchindex].rec_qty = BatchDetails.stock_total;
                            dgBatchEntity[dgSelectedBatchindex].comp_code = AppSessionState.comp_code;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = AppSessionState.location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = BatchDetails.sku;
                            dgBatchEntity[dgSelectedBatchindex].fin_year = "15-16";
                            dgBatchEntity[dgSelectedBatchindex].posting_period = "1";
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
        private void batchSelection(IList batchlist)
        {
            try
            {

                IList list = batchlist as IList;

                if (GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
                {

                    List<MM_T001_A> selectionbatch = list.Cast<MM_T001_A>().ToList();
                    if (selectionbatch.Count > 0 && dgSelectedIndex != -1)
                    {


                        var temp = (from o in MC.batchList
                                    where o.ItemCode == selectionbatch[0].ItemCode && o.sku == selectionbatch[0].sku
                                    select o);
                        batchCollection = CollectionViewSource.GetDefaultView(temp.ToList());
                        batchCollection.Filter = new Predicate<object>(Filterbatch);
                        stringListBatch = MC.batchList.Select(x => x.batch_no).ToList();

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
                if (dgBatchEntity != null && dgBatchEntity.Count > 0 && dgSelectedIndex < dgBatchEntity.Count && dgSelectedIndex >= 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(dgBatchEntity);
                    DataGridView.Filter = adv => ((MM_T001_B)adv).ItemCode.Equals(GoodsIssueDetails[dgSelectedIndex].ItemCode);
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
                        collectionOrderNo = CollectionViewSource.GetDefaultView(SoCollection.ToList());
                        collectionOrderNo.Filter = new Predicate<object>(FilterOrderDocNo);
                        StringListOrderNo = SoCollection.Select(x => x.order_no).ToList();
                    }
                    else if (MasterEntity.mov_tp == "104")
                    {
                        var ProjectCollection = (from o in MC.OrderDocNoList where o.doc_cat == "PR" select o).ToList();
                        collectionOrderNo = CollectionViewSource.GetDefaultView(ProjectCollection.ToList());
                        collectionOrderNo.Filter = new Predicate<object>(FilterOrderDocNo);
                        StringListOrderNo = ProjectCollection.Select(x => x.order_no).ToList();
                    }
                    else
                    {
                        var Collection = (from o in MC.OrderDocNoList where o.doc_cat == "ZZ" select o).ToList();
                        collectionOrderNo = CollectionViewSource.GetDefaultView(Collection.ToList());
                        collectionOrderNo.Refresh();
                        StringListOrderNo = Collection.Select(x => x.order_no).ToList();
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

                if (_FilterStringSearchItems != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchItems);
                    showMessageService.ShowMessage();
                }
                else if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
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
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            //posting_period = "1",
                            //fin_year = "15-16",
                            line_id = LineId,
                            store_code = store_location,
                            debcr_ind = "D",
                            mat_con = "New ",
                            para2 = "Local ",
                            para1 = MasterMake,
                            active = true,
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
                            GoodsIssueDetails[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            GoodsIssueDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            //GoodsIssueDetails[dgSelectedIndex].fin_year = "15-16";
                            //GoodsIssueDetails[dgSelectedIndex].posting_period = "1";
                            GoodsIssueDetails[dgSelectedIndex].store_code = store_location;
                            GoodsIssueDetails[dgSelectedIndex].qty = POPUPEntityObject.qty;
                            GoodsIssueDetails[dgSelectedIndex].order_doc_no = MasterEntity.order_doc_no;
                            GoodsIssueDetails[dgSelectedIndex].debcr_ind = "D";
                            GoodsIssueDetails[dgSelectedIndex].mat_con = "New ";
                            GoodsIssueDetails[dgSelectedIndex].para2 = "Local ";
                            GoodsIssueDetails[dgSelectedIndex].para1 = MasterMake;
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
                    //MachineCodeCollection = CollectionViewSource.GetDefaultView(MC.MachineCodeList);
                    //FilterStringMachine = GoodsIssueDetails[dgSelectedIndex-1].location_Id;
                    //MachineCodeCollection.Filter = new Predicate<object>(FilterMachine);
                    MachineCode_temp_list = (from o in MC.MachineCodeList
                                             where o.location_Id == GoodsIssueDetails[dgSelectedIndex - 1].location_Id
                                             select o).ToList();
                    MachineCodeCollection = CollectionViewSource.GetDefaultView(MachineCode_temp_list);
                    MachineCodeCollection.Filter = new Predicate<object>(FilterMachineCode);
                    StringListMachineCode = MachineCode_temp_list.Select(x => x.machinecode).ToList();
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
                            //               where o.location_Id == POPUPEntityObject.location_Id
                            //               select o).ToList();
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
                if (MC.MachineCodeList.Count > 0 && dgSelectedIndex >= 0 && GoodsIssueDetails.Count >= 0)
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
                            GoodsIssueDetails[dgSelectedIndex].machine_id = POPUPEntityObject.machine_id;
                            GoodsIssueDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
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
                                        posting_period = "1",
                                        fin_year = "15-16",
                                        sku = POPUPEntityObject.sku,
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
                                    dgBatchEntity[dgSelectedIndex].fin_year = "15-16";
                                    dgBatchEntity[dgSelectedIndex].posting_period = "1";
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
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_T003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {

                    MasterEntity.ref_doc = POPUPEntityObject.req_no;
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
        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

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

                            POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.para1 == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.para1 == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsIssueDetails[dgSelectedIndex].para1 = POPUPEntityObject.parametervalue;
                        }
                        else if (GoodsIssueDetails[dgSelectedIndex].para1 != POPUPEntityObject.parametervalue)
                        {
                            GoodsIssueDetails[dgSelectedIndex].para1 = "";
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
        //
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
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
                        {
                            Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + "LoadIndentNo" + "!@" + MasterEntity.ref_doc;
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

                            MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Issue", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                            if (ParametersStringValue == "ReferenceDocument")
                            {
                                MasterEntity.ref_doc = MasterEntity.ref_doc;
                                MasterEntity.ref_doc_date = MasterEntity.doc_date;
                                MasterEntity.doc_cat = "MI";
                                MasterEntity.doc_type = "MI";
                                MasterEntity.doc_no = "";
                                MasterEntity.doc_date = DateTime.Now;
                                MasterEntity.post_date = DateTime.Now;
                                MasterEntity.add_by = AppSessionState.UserID;
                                MasterEntity.editby = AppSessionState.UserID;
                                MasterEntity.fin_year = "15-16";
                                MasterEntity.posting_period = "1";
                                MasterEntity.active = true;
                                MasterEntity.t_status = "004";
                                MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
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
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + "LoadMaterialIssueItemDetail" + "!@" + ParameterEntityObject.doc_no;
                        NewRecord = false;
                        MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Issue", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                        AttachmentCollection = CollectionViewSource.GetDefaultView(MC.Attachment);
                        MoveFlag = false;
                    }
                }



                MasterEntity.ts_code = ts_code_vm;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");

                if (GoodsIssueDetails.Count > 0 && dgSelectedIndex != -1)
                {
                    TotalQty = 0;
                    TotalQty = Convert.ToDecimal(GoodsIssueDetails.Where(x => x.active == true).Sum(x => x.qty));
                }
                SelectedTabControlIndex = 0;
                parameter = false;
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
                else if (GoodsIssueDetails[dgSelectedIndex].StockUnt == true)
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
                var LineId = GoodsIssueDetails.Count + 1;
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
                            line_id = LineId,
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
                            para1 = EntityObject.para1,
                            para2 = EntityObject.para2
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

        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {

                if (sender.ToString() == "qty" && dgSelectedIndex != -1 && GoodsIssueDetails.Count >= 0)
                {
                    TotalQty = 0;
                    TotalQty = Convert.ToDecimal(GoodsIssueDetails.Where(x => x.active == true).Sum(x => x.qty));

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
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                if (e.Action == NotifyCollectionChangedAction.Add && GoodsIssueDetails.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    // foreach (MM_T001_A item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        if (dgSelectedIndex <= GoodsIssueDetails.Count && dgSelectedIndex != -1)
                        {
                            TotalQty = 0;
                            TotalQty = Convert.ToDecimal(GoodsIssueDetails.Where(x => x.active == true).Sum(x => x.qty));

                        }

                        //      item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (dgSelectedIndex <= GoodsIssueDetails.Count && dgSelectedIndex != -1)
                    {
                        TotalQty = 0;
                        TotalQty = Convert.ToDecimal(GoodsIssueDetails.Where(x => x.active == true).Sum(x => x.qty));

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
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


                SelectionChangedCommandRequester = new RelayCommand<object>(
                items =>
                {
                    if (items == null) { return; }
                    InsertRequster(items);
                });


                SelectionChangedCommandIndent = new RelayCommand<object>(
                items =>
                {
                    if (items == null) { return; }
                    InsertIndentNo(items);
                });

                SelectionChangedCommandDepartment = new RelayCommand<object>(
                items => { if (items == null) { return; } InsertDeptment(items); });

                SelectionChangedCommandMovType = new RelayCommand<object>(
                 items =>
                 {
                     if (items == null) { return; }
                     InsertMovementType(items);
                 });
                SelectionChangedCommandItem = new RelayCommand<object>(
                cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });

                SelectionChangedCommandUnit = new RelayCommand<object>
                (cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Uom(cmdPara, false, true, true); });

                SelectionChangedCommandStoreLocation = new RelayCommand<object>
                (cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });

                SelectionChangedCommandPlantA = new RelayCommand<object>
                (cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Plant(cmdPara, false, true, true); });

                SelectionChangedCommandbatch = new RelayCommand<object>
               (cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Batch(cmdPara, false, true, true); });

                SelectionChangedCommandOrderDocNo = new RelayCommand<object>
                  (items => { if (items == null) { return; } InsertOrderNoList(items); });

                DataGridRowDeleteCommand = new RelayCommand<object>(
               items =>
               {
                   if (items == null) { return; }
                   DeleteDataGridRow_Item(items);
               });
                DataGridRowDeleteCommandBatch = new RelayCommand<object>(
              items =>
              {
                  if (items == null) { return; }
                  DeleteDataGridRow_ItemBatch(items);
              });
                CollectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    CollectionChanged(items);

                });
                SelectionChangedParaValCommand = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedParaValue(items);
              });

                batchSelectionCommand = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 batchSelection(items);
             });

                SelectionChangedBatchDetailsCommand = new RelayCommand<object>(
                Items =>
                {
                    if (Items == null) { return; }
                    GetSelectedBatchForItem(Items, true, false, true);  // used for batch popup on batch details tab
                });

                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });

                ActiveInActiveChangeCommand = new RelayCommand<object>(
               items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });

                SelectionChangedCommandMachine = new RelayCommand<object>
                (cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_MachineCode(cmdPara, false, true, true); });

                cmdMake = new RelayCommand<IList>
                (cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });

                cmdMasterMake = new RelayCommand<object>(
                 items =>
                 {
                     if (items == null) { return; }
                     InsertMasterMake(items);
                 });

                cmdLoadRecords = new RelayCommand(() => { LoadRecords(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList where o.para_code == "1002" select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParamValueList where o.para_code == "1001" select o).ToList();
                TypeCollection = CollectionViewSource.GetDefaultView(Typelist.ToList());

                var matconlist = (from o in MC.ParamValueList where o.para_code == "1003" select o).ToList();
                MatConditionCollection = CollectionViewSource.GetDefaultView(matconlist.ToList());


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



                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                CollectionPlant_A = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                CollectionPlant_A.Filter = new Predicate<object>(FilterPlantA);
                stringListPlant = ObjSupply.Select(x => x.location_Id).ToList();

                store_temp_list = (List<MM_M001>)AppSessionState.store_location;
                CollectionStoreLocation = CollectionViewSource.GetDefaultView(store_temp_list);
                CollectionStoreLocation.Filter = new Predicate<object>(FilterStoreLoc);
                store_location = (from o in store_temp_list
                                  where o.location_Id == AppSessionState.location_Id && o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
                stringListStoreLoc = store_temp_list.Select(x => x.store_code).ToList();
                //if (store_temp_list.Count == 1)
                //{
                //    store_location = store_temp_list[0].store_code;
                //}

                CollectionIndent = CollectionViewSource.GetDefaultView(MC.IndentOrIndentNoList);
                CollectionIndent.Filter = new Predicate<object>(FilterIndent);
                StringListIndent = MC.IndentOrIndentNoList.Select(x => x.req_no).ToList();

                NotificationDataCollection = CollectionViewSource.GetDefaultView(MC.NotificationData);

                DefaultValues();
                MasterEntity.post_date = DateTime.Now;

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

        #region · Command Actions ·

        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "MI";
            MasterEntity.doc_code = "MI";
            MasterEntity.doc_type = "MI";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.vendor = "";
            MasterEntity.PartyId = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.fin_year = "15-16";
            MasterEntity.posting_period = "1";
            MasterEntity.po_code = AppSessionState.po_code;
            MasterEntity.pg_code = AppSessionState.pg_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.t_status = "004";
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
            else
            {
                GenerateSku();
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
                        //int flag = 0; //duplicate entry is allowed so commented : pending delete
                        //if (o.id == 0)
                        //{
                        //    foreach (var p in GoodsIssueDetails)
                        //    {
                        //        if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.machine_id == p.machine_id)
                        //        {
                        //            flag++;
                        //        }
                        //    }
                        //    if (flag > 1)
                        //    {
                        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //        showMessageService.ButtonSetup = DialogButton.Ok;
                        //        showMessageService.Caption = "Message";
                        //        showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} and machine {2}", o.ItemCode, o.sku_desc, o.machinecode);
                        //        showMessageService.ShowMessage();
                        //        return false;
                        //    }
                        //}

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
                        if (o.para1 == null || o.para1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Make for the Item {0}", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para2 == null || o.para2 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Type for the Item {0}", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.mat_con == null || o.mat_con == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Material Condition for the Item {0}", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.machine_id == null || o.machine_id == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select Machine for the Item {0}", o.ItemCode);
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
                        if (GoodsIssueDetails[i].ItemCode == dgBatchEntity[j].ItemCode && GoodsIssueDetails[i].sku == dgBatchEntity[j].sku)
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


            bool anyDuplicates = GoodsIssueDetails.Select(x => new { x.ItemCode, x.sku, x.machine_id, x.batch_no }).Distinct().Count()
                                                < GoodsIssueDetails.Count();

            if (anyDuplicates == true)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.OkCancel;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Duplicate Rows Found Click ok To Merge and Save Records. Or Click Cancel for Not Saving ");
                showMessageService.ShowMessage();

                if (showMessageService.ShowMessage() == DialogResult.Cancel)
                {
                    return false;
                }

            }


            return true;
        }
        private void GenerateSku()
        {
            string makecode = "";
            string typecode = "";
            string matconcode = "";

            foreach (var o in GoodsIssueDetails)
            {
                if (o.id == 0 && o.StockUnt==true)
                {
                    makecode = "";
                    typecode = "";
                    matconcode = "";

                    if (o.para1 != null && o.para2 != null && o.mat_con != null && o.para1 != "")
                    {
                        makecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para1.Trim() && X.para_code == "1002").Select(x => x.value_code).FirstOrDefault();
                        typecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para2.Trim() && X.para_code == "1001").Select(x => x.value_code).FirstOrDefault();
                        matconcode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.mat_con.Trim() && X.para_code == "1003").Select(x => x.value_code).FirstOrDefault();

                        o.sku = makecode + "/" + typecode + "/" + matconcode;
                        o.sku_desc = "Make:" + o.para1 + "\t" + "Type:" + o.para2 + "\t" + "MaterialCondition:" + o.mat_con;

                    }
                }
            }
        }
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {

                this.MasterEntity.EndEdit();

                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_MM_T001 = objSer.ObjectToXML(GoodsIssueDetails);
                    MasterEntity.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(dgBatchEntity);

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Issue", "SCM");
                        MoveFlag = false;
                    }

                    else if (NewRecord == false)
                    {

                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "Goods_Issue", "SCM");


                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (dgSelectedIndex <= GoodsIssueDetails.Count && dgSelectedIndex != -1)
                    {
                        TotalQty = 0;
                        TotalQty = Convert.ToDecimal(GoodsIssueDetails.Where(x => x.active == true).Sum(x => x.qty));

                    }
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();

                    NewRecord = false;
                    parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable
                    _dataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                }
                FilterStringSearchItems = "";
                _FilterStringSearchItems = "";
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
            MoveFlag = true;
            TotalQty = 0;
            _dataGridCollection.Refresh();
            MasterEntity = new MM_T001();
            DefaultValues();
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.ValidateAsync().Wait();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();

            FilterStringSearchItems = "";
            _FilterStringSearchItems = "";

            var Collection = (from o in MC.OrderDocNoList where o.doc_cat == "ZZ" select o).ToList();
            collectionOrderNo = CollectionViewSource.GetDefaultView(Collection.ToList());
            collectionOrderNo.Refresh();
            StringListOrderNo = Collection.Select(x => x.order_no).ToList();
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
                TotalQty = 0;
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
            throw new NotImplementedException();
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

        #region Filter For Search Box
        private string _FilterStringSearchItems = "";
        public string FilterStringSearchItems
        {
            get { return _FilterStringSearchItems; }
            set
            {
                _FilterStringSearchItems = value;
                RaisePropertyChanged("FilterStringSearchItems");
                //PartyCollection = CollectionViewSource.GetDefaultView(CustEntity);
                //PartyCollection.Filter = new Predicate<object>(FilterParty);
                FilterCollectionSearchItems();
            }
        }
        private void FilterCollectionSearchItems()
        {
            try
            {
                SearchItemsCollection = CollectionViewSource.GetDefaultView(GoodsIssueDetails);
                SearchItemsCollection.Filter = new Predicate<object>(FilterSearchItems);
                if (_SearchItemsCollection != null)
                {
                    _SearchItemsCollection.Refresh();
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
        public bool FilterSearchItems(object obj)
        {
            var data = obj as MM_T001_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchItems))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower()) ||
                           (data.para1 != null && data.para1.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.mat_con != null && data.mat_con.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.para2 != null && data.para2.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion

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

        #region Filters For Make
        private string _filterStringMake;
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        public bool FilterMake(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringMake.ToLower());
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
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterStringOrderDocNo.ToLower()));
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
