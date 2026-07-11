//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using Reflection.WebServices.Gateway;
//using Reflection.Presentation.Core.Services;
//using Reflection.Presentation.Core.Windows;
//using System.Windows.Data;
//using GalaSoft.MvvmLight.Command;
//using System.Collections.ObjectModel;
//using Reflection.Presentation.Services;
//using Reflection.Presentation.ViewModel;
//using Reflection.BusinessEntity;
//using System.Windows.Controls;
//using Reflection.Presentation.Controls;
//using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
//using GalaSoft.MvvmLight.Messaging;
//using Reflection.Presentation.Services.Convertors;
//using Reflection.ReportingServices;
//using Reflection.Presentation.Common;
//using Reflection.BusinessEntity.PMS;

//namespace Reflection.Modules.PMS.ViewModels
//{
//    public class PMS_T006_VM : WorkspaceViewModel<PMS_T001>
//    {
//        #region AutoSuggest Initialization
//        private DataGridCellInfo _cellInfo;
//        public DataGridCellInfo CellInfo
//        {
//            get { return _cellInfo; }
//            set
//            {
//                _cellInfo = value;
//                SetAutoTextSource(_cellInfo);
//                RaisePropertyChanged("CellInfo");
//            }
//        }
//        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
//        {
//            if (dgCellInfo != null)
//            {
//                var column = dgCellInfo.Column as DataGridColumn;
//                if (column != null)
//                {
//                    string headerName = column.Header.ToString();
//                    string SourceName = column.SortMemberPath.ToString();
//                    if (SourceName == "batch_no")
//                    { ASDefault = ASBatchItem; }

//                }
//            }
//        }
//        public Func<object, string, bool> TheFilter { get; set; }
//        public static IValueConverter SuggestedValue { get; set; }
//        public AutoSuggestViewModel AutoSuggestVM { get; set; }
//        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASDefault
//        {
//            get { return _ASDefault; }
//            set
//            {
//                if (_ASDefault != value)
//                {
//                    _ASDefault = value; RaisePropertyChanged("ASDefault");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASBatchItem { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASBatchItem
//        {
//            get { return _ASBatchItem; }
//            set
//            {
//                if (_ASBatchItem != value)
//                {
//                    _ASBatchItem = value; RaisePropertyChanged("ASBatchItem");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASPlant
//        {
//            get { return _ASPlant; }
//            set
//            {
//                if (_ASPlant != value)
//                {
//                    _ASPlant = value; RaisePropertyChanged("ASPlant");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASStore { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASStore
//        {
//            get { return _ASStore; }
//            set
//            {
//                if (_ASStore != value)
//                {
//                    _ASStore = value; RaisePropertyChanged("ASStore");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASCompany
//        {
//            get { return _ASCompany; }
//            set
//            {
//                if (_ASCompany != value)
//                {
//                    _ASCompany = value; RaisePropertyChanged("ASCompany");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASDefaultBatch { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASDefaultBatch
//        {
//            get { return _ASDefaultBatch; }
//            set
//            {
//                if (_ASDefaultBatch != value)
//                {
//                    _ASDefaultBatch = value; RaisePropertyChanged("ASDefaultBatch");
//                }
//            }
//        }
//        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASDocType
//        {
//            get { return _ASDocType; }
//            set
//            {
//                if (_ASDocType != value)
//                {
//                    _ASDocType = value; RaisePropertyChanged("ASDocType");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASPriority { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASPriority
//        {
//            get { return _ASPriority; }
//            set
//            {
//                if (_ASPriority != value)
//                {
//                    _ASPriority = value; RaisePropertyChanged("ASPriority");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASDepartment
//        {
//            get { return _ASDepartment; }
//            set
//            {
//                if (_ASDepartment != value)
//                {
//                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASRequester { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASRequester
//        {
//            get { return _ASRequester; }
//            set
//            {
//                if (_ASRequester != value)
//                {
//                    _ASRequester = value; RaisePropertyChanged("ASRequester");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASBom { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASBom
//        {
//            get { return _ASBom; }
//            set
//            {
//                if (_ASBom != value)
//                {
//                    _ASBom = value; RaisePropertyChanged("ASBom");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASItem
//        {
//            get { return _ASItem; }
//            set
//            {
//                if (_ASItem != value)
//                {
//                    _ASItem = value; RaisePropertyChanged("ASItem");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASMachine { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASMachine
//        {
//            get { return _ASMachine; }
//            set
//            {
//                if (_ASMachine != value)
//                {
//                    _ASMachine = value; RaisePropertyChanged("ASMachine");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASOrder { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASOrder
//        {
//            get { return _ASOrder; }
//            set
//            {
//                if (_ASOrder != value)
//                {
//                    _ASOrder = value; RaisePropertyChanged("ASOrder");
//                }
//            }
//        }

//        private AutoSuggestTextViewModel<dynamic> _ASProductionOrders { get; set; }
//        public AutoSuggestTextViewModel<dynamic> ASProductionOrders
//        {
//            get { return _ASProductionOrders; }
//            set
//            {
//                if (_ASProductionOrders != value)
//                {
//                    _ASProductionOrders = value; RaisePropertyChanged("ASProductionOrders");
//                }
//            }
//        }

//        #endregion

//        #region Variable Declaration
//        bool isNewRecord = true;
//        WebServiceRepository<PMS_T001> repository = new WebServiceRepository<PMS_T001>();
//        WebServiceRepository<string> repositoryStr = new WebServiceRepository<string>();
//        WebServiceRepository<MultipleContext_MM_T003> repository_MC = new WebServiceRepository<MultipleContext_MM_T003>();
//        WebServiceRepository<MultipleContext_MM_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_MM_T003>();
//        WebServiceRepository<MultipleContext_MM_T003> repository_MCTemp2 = new WebServiceRepository<MultipleContext_MM_T003>();
//        ObjectSerializationService obj = new ObjectSerializationService();

//        public string ts_code_vm { get; set; }
//        public string doc_no_vm { get; set; }

//        private MultipleContext_MM_T003 _MC = new MultipleContext_MM_T003();
//        public MultipleContext_MM_T003 MC
//        {
//            get { return _MC; }
//            set
//            {
//                if (_MC != value)
//                {
//                    _MC = value; RaisePropertyChanged("MC");

//                }
//            }

//        }
//        private SearchEntity _SearchEntityObject;
//        public SearchEntity SearchEntityObject
//        {
//            get
//            {
//                return _SearchEntityObject;
//            }
//            set
//            {
//                if (_SearchEntityObject != value)
//                {
//                    _SearchEntityObject = value;
//                    RaisePropertyChanged(nameof(SearchEntityObject));
//                }
//            }
//        }
//        private MultipleContext_MM_T003 _MCTemp = new MultipleContext_MM_T003();
//        public MultipleContext_MM_T003 MCTemp
//        {
//            get { return _MCTemp; }
//            set
//            {
//                if (_MCTemp != value)
//                {
//                    _MCTemp = value; RaisePropertyChanged("MCTemp");
//                }
//            }
//        }

//        private string _store_location;
//        public string store_location
//        {
//            get { return _store_location; }
//            set
//            {
//                if (_store_location != value)
//                {
//                    _store_location = value; RaisePropertyChanged("store_location");
//                }
//            }
//        }
//        private List<MM_M001> _store_temp_list;
//        public List<MM_M001> store_temp_list
//        {
//            get { return _store_temp_list; }
//            set
//            {
//                if (_store_temp_list != value)
//                {
//                    _store_temp_list = value;


//                }
//            }
//        }
//        public List<ADM_M002> _ObjCompany = new List<ADM_M002>();
//        private List<ADM_M002> ObjCompany
//        {
//            get { return _ObjCompany; }
//            set
//            {
//                if (_ObjCompany != value)
//                {
//                    _ObjCompany = value;
//                }
//            }
//        }
//        public List<ADM_M003> _ObjLocation = new List<ADM_M003>();
//        private List<ADM_M003> ObjLocation
//        {
//            get { return _ObjLocation; }
//            set
//            {
//                if (_ObjLocation != value)
//                {
//                    _ObjLocation = value;
//                }
//            }
//        }
//        private MultipleContext_MM_T003 _MCTemp2 = new MultipleContext_MM_T003();
//        public MultipleContext_MM_T003 MCTemp2
//        {
//            get { return _MCTemp2; }
//            set
//            {
//                if (_MCTemp2 != value)
//                {
//                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
//                }
//            }
//        }

//        private PMS_T001 _MasterEntity;
//        public PMS_T001 MasterEntity
//        {
//            get { return _MasterEntity; }
//            set
//            {
//                if (_MasterEntity != value)
//                {
//                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
//                    //value.BeginEdit();
//                }
//            }
//        }

//        private ObservableCollection<MM_T003_A> _ItemsEntity;
//        public ObservableCollection<MM_T003_A> ItemsEntity
//        {
//            get { return _ItemsEntity; }
//            set
//            {
//                if (_ItemsEntity != value)
//                {
//                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
//                    //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
//                }
//            }
//        }

//        private int _dgSelectedIndexItem;
//        public int dgSelectedIndexItem
//        {
//            get
//            {
//                return _dgSelectedIndexItem;
//            }
//            set
//            {
//                if (_dgSelectedIndexItem != value)
//                {
//                    _dgSelectedIndexItem = value;
//                    RaisePropertyChanged("dgSelectedIndexItem");
//                    //if (TotalDocumentTaxesItem.Count > 0)
//                    //{
//                    //    TotalDocumentTaxesItem = new ObservableCollection<PUR_T005_C>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id));
//                    //}
//                }
//            }
//        }
//        private int _selectedTabControlIndex;
//        public int SelectedTabControlIndex
//        {
//            get { return _selectedTabControlIndex; }
//            set
//            {
//                if (_selectedTabControlIndex != value)
//                {
//                    _selectedTabControlIndex = value;
//                    RaisePropertyChanged("SelectedTabControlIndex");
//                }
//            }
//        }
//        private bool _post;
//        public bool post
//        {
//            get { return _post; }
//            set
//            {
//                if (_post != value)
//                {
//                    _post = value;
//                    RaisePropertyChanged("post");
//                }
//            }
//        }

//        private bool _parameter;
//        public bool parameter
//        {
//            get { return _parameter; }
//            set
//            {
//                if (_parameter != value)
//                {
//                    _parameter = value;
//                    RaisePropertyChanged("parameter");
//                }
//            }
//        }
//        List<ADM_M022_P> _ItemList = new List<ADM_M022_P>();
//        public List<ADM_M022_P> ItemList
//        {
//            get { return _ItemList; }
//            set
//            {
//                if (_ItemList != value)
//                {
//                    _ItemList = value;

//                    RaisePropertyChanged("ItemList");
//                }
//            }
//        }
//        private PMS_T001 _ObjectMM_T003;
//        public PMS_T001 ObjectMM_T003
//        {
//            get
//            {
//                return _ObjectMM_T003;
//            }
//            set
//            {
//                if (_ObjectMM_T003 != value)
//                {
//                    _ObjectMM_T003 = value;
//                    RaisePropertyChanged("ObjectMM_T003");
//                }
//            }
//        }
//        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
//        public List<ADM_M031_P> ParameterTemp
//        {
//            get { return _ParameterTemp; }
//            set
//            {
//                if (_ParameterTemp != value)
//                {
//                    _ParameterTemp = value;
//                }
//            }
//        }

//        #endregion

//        #region Model Entity Update
//        void ModelUpdated_Master(object sender, EventArgs e)
//        {
//            //This will get called when the property of an object inside the collection changes
//            this.ErrorExist = MasterEntity.HasErrors;
//            if (sender.ToString() == "req_ref")
//            {
//                if (!string.IsNullOrWhiteSpace(MasterEntity.req_ref) && MC.ProductionOrderList != null)
//                {
//                    if (MC.ProductionOrderList.Count > 0)
//                    {
//                        MasterEntity.bom_no = MC.ProductionOrderList.Where(b => b.order_no == MasterEntity.req_ref).ToList()[0].bom_no;
//                    }
//                }
//            }
//        }
//        void ModelUpdated_Item(object sender, EventArgs e)
//        {
//            this.ErrorExist = MasterEntity.HasErrors;

//        }

//        #endregion

//        #region List     
//        private List<MM_T003Flip> _FlipGridData;
//        // Flip DataGrid Data Source
//        public List<MM_T003Flip> FlipGridData
//        {
//            get { return _FlipGridData; }
//            set
//            {
//                if (_FlipGridData != value)
//                {
//                    _FlipGridData = value;
//                    RaisePropertyChanged("FlipGridData");
//                }
//            }
//        }
//        List<string> _strListPriority;
//        public List<string> StringListPriority
//        {
//            get { return _strListPriority; }
//            set
//            {
//                if (_strListPriority != value)
//                {
//                    _strListPriority = value;
//                }
//            }
//        }
//        List<string> _strListRequster;

//        private List<string> _StringListBOM;
//        public List<string> StringListBOM
//        {
//            get { return _StringListBOM; }
//            set
//            {
//                if (_StringListBOM != value)
//                {
//                    _StringListBOM = value;
//                }
//            }
//        }
//        public List<string> StringListRequster
//        {
//            get { return _strListRequster; }
//            set
//            {
//                if (_strListRequster != value)
//                {
//                    _strListRequster = value;
//                }
//            }
//        }
//        List<string> _strListDept;
//        public List<string> StringListDept
//        {
//            get { return _strListDept; }
//            set
//            {
//                if (_strListDept != value)
//                {
//                    _strListDept = value;
//                }
//            }
//        }
//        List<string> _stringListItems;
//        public List<string> StringListItems
//        {
//            get { return _stringListItems; }
//            set
//            {
//                if (_stringListItems != value)
//                {
//                    _stringListItems = value;
//                }
//            }
//        }
//        private List<string> _strListItemCategory;
//        public List<string> StringListItemCategory
//        {
//            get { return _strListItemCategory; }
//            set
//            {
//                if (_strListItemCategory != value)
//                {
//                    _strListItemCategory = value;
//                }
//            }
//        }
//        List<string> _stringListUOM;
//        public List<string> StringListUOM
//        {
//            get { return _stringListUOM; }
//            set
//            {
//                if (_stringListUOM != value)
//                {
//                    _stringListUOM = value;
//                }
//            }
//        }
//        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
//        public List<ADM_M031_P> SelectedParaValueCollection
//        {
//            get { return _SelectedParaValueCollection; }
//            set
//            {
//                if (_SelectedParaValueCollection != value)
//                {
//                    _SelectedParaValueCollection = value;
//                    RaisePropertyChanged("SelectedParaValueCollection");
//                }
//            }
//        }

//        private List<string> _StringListMachine;
//        public List<string> StringListMachine
//        {
//            get { return _StringListMachine; }
//            set
//            {
//                if (_StringListMachine != value)
//                {
//                    _StringListMachine = value;
//                }
//            }
//        }

//        private List<string> _StringListDocType;
//        public List<string> StringListDocType
//        {
//            get { return _StringListDocType; }
//            set
//            {
//                if (_StringListDocType != value)
//                {
//                    _StringListDocType = value;
//                }
//            }
//        }

//        private List<String> _StrListOrderNo;
//        public List<string> StrListOrderNo
//        {
//            get { return _StrListOrderNo; }
//            set
//            {
//                if (_StrListOrderNo != value)
//                {
//                    _StrListOrderNo = value;
//                }
//            }
//        }

//        private int _ParadgSelectedIndex;
//        public int ParadgSelectedIndex
//        {
//            get
//            {
//                return _ParadgSelectedIndex;
//            }
//            set
//            {
//                if (_ParadgSelectedIndex != value)
//                {
//                    _ParadgSelectedIndex = value;
//                    RaisePropertyChanged("ParadgSelectedIndex");
//                }
//            }
//        }

//        #endregion

//        #region ICollection
//        private ICollectionView _dataGridCollection;
//        public ICollectionView DataGridCollection
//        {
//            get { return _dataGridCollection; }
//            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
//        }

//        private ICollectionView _BomCollection;
//        public ICollectionView BomCollection
//        {
//            get { return _BomCollection; }
//            set { _BomCollection = value; RaisePropertyChanged("BomCollection"); }
//        }

//        private ICollectionView _PriorityCollection;
//        public ICollectionView PriorityCollection
//        {
//            get { return _PriorityCollection; }
//            set
//            {
//                _PriorityCollection = value;

//                RaisePropertyChanged("PriorityCollection");
//            }
//        }
//        private ICollectionView _RequesterCollection;
//        public ICollectionView RequesterCollection
//        {
//            get { return _RequesterCollection; }
//            set { _RequesterCollection = value; RaisePropertyChanged("RequesterCollection"); }
//        }
//        private ICollectionView _DepartmentCollection;
//        public ICollectionView DepartmentCollection
//        {
//            get { return _DepartmentCollection; }
//            set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
//        }
//        private ICollectionView _ItemsCollection;
//        public ICollectionView ItemsCollection
//        {
//            get { return _ItemsCollection; }
//            set
//            {
//                _ItemsCollection = value;

//                RaisePropertyChanged("ItemsCollection");
//            }
//        }
//        private ICollectionView _ParameterCollection;
//        public ICollectionView ParameterCollection
//        {
//            get { return _ParameterCollection; }
//            set
//            {
//                _ParameterCollection = value;
//                RaisePropertyChanged("ParameterCollection")
//                ;
//            }
//        }
//        private ICollectionView _ParameterValueCollection;
//        public ICollectionView ParameterValueCollection
//        {
//            get { return _ParameterValueCollection; }
//            set
//            {
//                _ParameterValueCollection = value;
//                RaisePropertyChanged("ParameterValueCollection")
//                ;
//            }
//        }
//        private ICollectionView _itemcategoryCollection;
//        public ICollectionView itemcategoryCollection
//        {
//            get { return _itemcategoryCollection; }
//            set
//            {
//                _itemcategoryCollection = value;
//                RaisePropertyChanged("itemcategoryCollection");
//            }
//        }
//        private ICollectionView _uomCollection;
//        public ICollectionView uomCollection
//        {
//            get { return _uomCollection; }
//            set
//            {
//                _uomCollection = value;

//                RaisePropertyChanged("uomCollection");
//            }
//        }
//        private ICollectionView _MachineCollection;
//        public ICollectionView MachineCollection
//        {
//            get { return _MachineCollection; }
//            set
//            {
//                _MachineCollection = value;

//                RaisePropertyChanged("MachineCollection");
//            }
//        }

//        private ICollectionView _DocTypeCollection;
//        public ICollectionView DocTypeCollection
//        {
//            get { return _DocTypeCollection; }
//            set
//            {
//                _DocTypeCollection = value;

//                RaisePropertyChanged("DocTypeCollection");
//            }
//        }

//        private ICollectionView _OrderNoCollection;
//        public ICollectionView OrderNoCollection
//        {

//            get { return _OrderNoCollection; }
//            set
//            {
//                _OrderNoCollection = value;

//                RaisePropertyChanged("OrderNoCollection");
//            }
//        }
//        #endregion

//        #region Relay Command
//        public RelayCommand<object> SelectionChangedCommandStoreLocation
//        {
//            get;
//            private set;
//        }
//        public RelayCommand<object> SelectionChangedCommandbatch { get; private set; }
//        public RelayCommand<object> CommandInsertPriority { get; private set; }
//        public RelayCommand<object> CommandInsertRequester { get; private set; }
//        public RelayCommand<object> CommandInsertDepartment { get; private set; }
//        public RelayCommand<object> CommandInsertItems { get; private set; }
//        public RelayCommand<object> CommandAddItemCategory { get; private set; }
//        public RelayCommand<object> CommandInsertUOM { get; private set; }
//        public RelayCommand<object> DataGridRowDeleteCommand { get; private set; }
//        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
//        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
//        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
//        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
//        public GalaSoft.MvvmLight.Command.RelayCommand CommandForStatusChange { get; private set; }
//        public RelayCommand<object> CmdInsertMachine { get; private set; }
//        public RelayCommand<object> CmdInsertOrder { get; private set; }
//        public RelayCommand<object> CmdInsertDocType { get; private set; }
//        public GalaSoft.MvvmLight.Command.RelayCommand CmdForcefullycloseIndent { get; private set; }
//        public RelayCommand<object> CmdBOM { get; private set; }
//        public GalaSoft.MvvmLight.Command.RelayCommand cmdExecuteReference { get; private set; }
//        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
//        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
//        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }


//        #endregion

//        #region DefalutValue
//        private void DefaultValues()
//        {
//            MasterEntity.ts_code = ts_code_vm;
//            MasterEntity.doc_cat = "IO";
//            MasterEntity.doc_type = "IO";
//            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
//            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
//            MasterEntity.add_by = AppSessionState.UserID;
//            MasterEntity.editby = AppSessionState.UserID;
//            MasterEntity.dept_code = AppSessionState.dept_code;
//            MasterEntity.active = true;
//            MasterEntity.t_status = "01";
//            MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
//            MasterEntity.date_start = DateTime.Now;
//            MasterEntity.deadline = DateTime.Now;
//            MasterEntity.EmpId = AppSessionState.EmpId;
//            MasterEntity.client = AppSessionState.client;


//            MasterEntity.dept_code = MC.RequsterList.Where(x => x.EmpId.Equals(MasterEntity.EmpId, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].dept_code;
//            MasterEntity.Dept_Name = MC.RequsterList.Where(x => x.EmpId.Equals(MasterEntity.EmpId, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].DeptName;
//            SearchEntityObject.from_date = DateTime.Now.Date;
//            SearchEntityObject.to_date = DateTime.Now.Date;
//            SearchEntityObject.active = true;
//            MasterEntity.user_source1 = AppSessionState.UserSource1;
//            MasterEntity.user_source2 = AppSessionState.UserSource2;
//            MasterEntity.userid = AppSessionState.UserID;
//        }
//        private bool Validation()
//        {
//            try
//            {
//                if (MasterEntity.doc_type == null)
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Required";
//                    showMessageService.Text = String.Format("Please Select Document Type........");
//                    showMessageService.ShowMessage();

//                    return false;
//                }
//                if (MasterEntity.comp_code == null)
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Required";
//                    showMessageService.Text = String.Format("Please Select Company........");
//                    showMessageService.ShowMessage();

//                    return false;
//                }
//                if (MasterEntity.location_Id == null)
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Required";
//                    showMessageService.Text = String.Format("Please Select Plant........");
//                    showMessageService.ShowMessage();

//                    return false;
//                }

//                if (MasterEntity.EmpId == null)
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Required";
//                    showMessageService.Text = String.Format("Please Select Requester Name........");
//                    showMessageService.ShowMessage();

//                    return false;
//                }

//                if (ItemsEntity.Count < 1)//when form is blank and we save the record
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Message";
//                    showMessageService.Text = String.Format("At Least Insert One Item........");
//                    showMessageService.ShowMessage();

//                    return false;
//                }
//                else
//                {
//                    foreach (var o in ItemsEntity)
//                    {
//                        if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
//                        {
//                            int flag = 0;
//                            if (o.id == 0)
//                            {
//                                foreach (var p in ItemsEntity)
//                                {
//                                    if (o.ItemCode == p.ItemCode && o.sku == p.sku)
//                                    {
//                                        flag++;
//                                    }
//                                }
//                                if (flag > 1)
//                                {
//                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                                    showMessageService.ButtonSetup = DialogButton.Ok;
//                                    showMessageService.Caption = "Message";
//                                    showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
//                                    showMessageService.ShowMessage();
//                                    return false;
//                                }
//                            }


//                            // Validation For All Parameter Values Selected or Not


//                            if (o.qty == null || o.qty == 0)
//                            {
//                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                                showMessageService.ButtonSetup = DialogButton.Ok;
//                                showMessageService.Caption = "Message";
//                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
//                                showMessageService.ShowMessage();
//                                return false;
//                            }
//                            if (string.IsNullOrWhiteSpace(o.store_code) && MC.MM_T003_SETTING[0].ind_store_code == "Y")
//                            {
//                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                                showMessageService.ButtonSetup = DialogButton.Ok;
//                                showMessageService.Caption = "Message";
//                                showMessageService.Text = "Store Code required";
//                                showMessageService.ShowMessage();
//                                return false;
//                            }

//                        }
//                        else
//                        {

//                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                            showMessageService.ButtonSetup = DialogButton.Ok;
//                            showMessageService.Caption = "Message";
//                            showMessageService.Text = String.Format("please select Item ........");
//                            showMessageService.ShowMessage();
//                            return false;
//                        }
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//            return true;
//        }
//        #endregion

//        #region Constructor
//        public PMS_T006_VM(string ts_code) : base()
//        {
//            this.ts_code_vm = ts_code;
//            SearchEntityObject = new SearchEntity();
//            MC = new MultipleContext_MM_T003();
//            MCTemp = new MultipleContext_MM_T003();
//            MCTemp2 = new MultipleContext_MM_T003();
//            MasterEntity = new PMS_T001();
//            ItemsEntity = new ObservableCollection<MM_T003_A>();
//            FlipGridData = new List<MM_T003Flip>();

//            MasterEntity.ValidateAsync().Wait();

//            MasterEntity.ValidateAsync().Wait();
//            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
//            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
//            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

//            LoadInitialData();

//        }
//        public PMS_T006_VM(string ts_code, string doc_no) : base()
//        {
//            this.ts_code_vm = ts_code;
//            this.doc_no_vm = doc_no;
//            SearchEntityObject = new SearchEntity();
//            MC = new MultipleContext_MM_T003();
//            MCTemp = new MultipleContext_MM_T003();
//            MCTemp2 = new MultipleContext_MM_T003();
//            MasterEntity = new PMS_T001();
//            ItemsEntity = new ObservableCollection<MM_T003_A>();
//            FlipGridData = new List<MM_T003Flip>();

//            MasterEntity.ValidateAsync().Wait();

//            MasterEntity.ValidateAsync().Wait();
//            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
//            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
//            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

//            LoadInitialData();

//        }
//        #endregion

//        #region Method Implementation
//        private void LoadInitialData()
//        {
//            try
//            {
//                MasterEntity.doc_cat = "IO";
//                //MasterEntity.doc_type = "IO";
//                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client;
//                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MM_T003>(MC, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

//                #region Command Initialisation
//                SelectionChangedCommandStoreLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });
//                SelectionChangedCommandbatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Batch(cmdPara, false, true, true); });
//                CommandInsertPriority = new RelayCommand<object>(items => { if (items == null) { return; } InsertPriority(items); });
//                CommandInsertRequester = new RelayCommand<object>(items => { if (items == null) { return; } InsertRequster(items); });
//                CommandInsertDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeptment(items); });
//                CommandInsertItems = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
//                CommandAddItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
//                CommandInsertUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
//                CommandForStatusChange = new GalaSoft.MvvmLight.Command.RelayCommand(() => { Post(); });
//                CmdInsertMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara, false, true, true); });
//                CmdInsertOrder = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOrder(cmdPara, false, true, true); });
//                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
//                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
//                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
//                DataGridRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
//                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } GetselectedSkuParameter(items); });
//                CmdInsertDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
//                CmdForcefullycloseIndent = new GalaSoft.MvvmLight.Command.RelayCommand(() => { CloseIndentForcefully(); });
//                CmdBOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertBOM(items); });
//                cmdExecuteReference = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ExecuteReference(); });
//                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
//                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
//                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
//                #endregion
//                #region AutoSuggest Region
//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M011_P)x).doc_type_user);
//                TheFilter = (o, prefix) => ((SYS_M011_P)o).doc_type_user.ToLower().Contains(prefix.ToLower()) || ((SYS_M011_P)o).doc_desc_user.ToLower().Contains(prefix.ToLower());
//                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocType, TheFilter, SuggestedValue, "doc_type_user", true);
//                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M040_P)x).priority.ToString());
//                TheFilter = (o, prefix) => ((ADM_M040_P)o).priority.ToString().ToLower().Contains(prefix.ToLower());
//                ASPriority = new AutoSuggestTextViewModel<dynamic>(MC.PrioritiesList, TheFilter, SuggestedValue, "priority", true);
//                ASPriority.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code.ToString());
//                TheFilter = (o, prefix) => ((ADM_M025_P)o).dept_code.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M025_P)o).DeptName.ToString().ToLower().Contains(prefix.ToLower());
//                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC.DeptList, TheFilter, SuggestedValue, "dept_code", true);
//                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId.ToString());
//                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M024_P)o).EmpName.ToString().ToLower().Contains(prefix.ToLower());
//                ASRequester = new AutoSuggestTextViewModel<dynamic>(MC.RequsterList, TheFilter, SuggestedValue, "EmpId", true);
//                ASRequester.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no.ToString());
//                TheFilter = (o, prefix) => ((ENG_T001_P)o).doc_no.ToString().ToLower().Contains(prefix.ToLower());
//                ASBom = new AutoSuggestTextViewModel<dynamic>(MC.BOMData, TheFilter, SuggestedValue, "doc_no", true);
//                ASBom.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode.ToString());
//                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M022_P)o).ItemName.ToString().ToLower().Contains(prefix.ToLower());
//                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
//                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode.ToString());
//                TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.ToString().ToLower().Contains(prefix.ToLower());
//                ASMachine = new AutoSuggestTextViewModel<dynamic>(MC.MachineList, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
//                ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001_P)x).order_no.ToString());
//                TheFilter = (o, prefix) => ((EPR_T001_P)o).order_no.ToString().ToLower().Contains(prefix.ToLower());
//                ASOrder = new AutoSuggestTextViewModel<dynamic>(MC.OrderList, TheFilter, SuggestedValue, "order_no", "order_no", true);

//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no.ToString());
//                TheFilter = (o, prefix) => ((EPR_T001)o).order_no.ToString().ToLower().Contains(prefix.ToLower()) || ((EPR_T001)o).ItemCode.ToString().ToLower().Contains(prefix.ToLower()) || ((EPR_T001)o).ItemName.ToString().ToLower().Contains(prefix.ToLower());
//                ASProductionOrders = new AutoSuggestTextViewModel<dynamic>(MC.ProductionOrderList, TheFilter, SuggestedValue, "req_ref", "req_ref", true);
//                ASProductionOrders.AutoSuggestVM.IsEmptyValueAllowed = true;
//                #endregion

//                //FlipGridData = MC.DocumentDataFlipGrid.ToList();
//                //DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
//                //DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

//                BomCollection = CollectionViewSource.GetDefaultView(MC.BOMData);
//                BomCollection.Filter = new Predicate<object>(FilterBOM);
//                StringListBOM = MC.BOMData.Select(x => x.doc_no).ToList();

//                PriorityCollection = CollectionViewSource.GetDefaultView(MC.PrioritiesList);
//                PriorityCollection.Filter = new Predicate<object>(PriorityFilter);
//                StringListPriority = MC.PrioritiesList.Select(x => x.priority).ToList();

//                RequesterCollection = CollectionViewSource.GetDefaultView(MC.RequsterList);
//                RequesterCollection.Filter = new Predicate<object>(Filterrequest);
//                StringListRequster = MC.RequsterList.Select(x => x.EmpId).ToList();

//                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.DeptList);
//                DepartmentCollection.Filter = new Predicate<object>(FilterDept);
//                StringListDept = MC.DeptList.Select(x => x.dept_code).ToList();

//                ItemsCollection = (ICollectionView)CollectionViewSource.GetDefaultView(MC.ItemList);
//                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
//                StringListItems = MC.ItemList.Select(x => x.ItemCode).ToList();

//                itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.ItemCategoryList);
//                itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);
//                StringListItemCategory = MC.ItemCategoryList.Select(x => x.item_cat).ToList();

//                uomCollection = CollectionViewSource.GetDefaultView(MC.UnitList.ToList());
//                uomCollection.Filter = new Predicate<object>(Filter_UOM);
//                StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

//                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList.ToList());
//                MachineCollection.Filter = new Predicate<object>(Filter_Machine);
//                StringListMachine = MC.MachineList.Select(x => x.machinecode).ToList();

//                DocTypeCollection = CollectionViewSource.GetDefaultView(MC.DocType.ToList());
//                DocTypeCollection.Filter = new Predicate<object>(Filter_DocType);
//                StringListDocType = MC.DocType.Select(x => x.doc_type_user).ToList();

//                OrderNoCollection = CollectionViewSource.GetDefaultView(MC.ProductionOrderList.ToList());
//                OrderNoCollection.Filter = new Predicate<object>(FilterOrderNo);
//                StrListOrderNo = MC.OrderList.Select(x => x.order_no).ToList();

//                ObjCompany = (List<ADM_M002>)AppSessionState.ADM_M002_List;
//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
//                TheFilter = (o, prefix) => ((ADM_M002)o).comp_code.ToLower().Contains(prefix.ToLower());
//                ASCompany = new AutoSuggestTextViewModel<dynamic>(ObjCompany, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
//                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;



//                ObjLocation = (List<ADM_M003>)AppSessionState.ADM_M003_List;
//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
//                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower());
//                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjLocation, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
//                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

//                store_temp_list = (List<MM_M001>)AppSessionState.store_location;
//                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001)x).store_code);
//                TheFilter = (o, prefix) => ((MM_M001)o).store_code.ToLower().Contains(prefix.ToLower());
//                ASStore = new AutoSuggestTextViewModel<dynamic>(store_temp_list, TheFilter, SuggestedValue, "store_code", "store_code", true);
//                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;
//                store_temp_list = ((List<MM_M001>)AppSessionState.store_location).Where(x => x.location_Id == AppSessionState.OBJ_LOCATION.location_id && x.client == AppSessionState.client).ToList();
//                if (store_temp_list.Count == 1)
//                {
//                    store_location = store_temp_list[0].store_code;
//                }
//                DefaultValues();
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }

//        private void LoadBackFlipData(object Parameter)
//        {
//            try
//            {
//                CursorControl.SetBusyState();
//                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + SearchEntityObject.active + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString() + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString() + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId;

//                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

//                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
//                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
//                DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

//                //var msg = new NotificationMessage("SEL_T001_VM");
//                //Messenger.Default.Send<NotificationMessage>(msg);
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void batchSelection(IList batchlist)
//        {
//            try
//            {
//                IList list = batchlist as IList;
//                if (ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
//                {

//                    List<MM_T003_A> selectionbatch = list.Cast<MM_T003_A>().ToList();
//                    if (selectionbatch.Count > 0 && dgSelectedIndexItem != -1)
//                    {


//                        var temp = (from o in MC.batchList
//                                    where o.ItemCode == selectionbatch[0].ItemCode && (o.sku ?? "") == (selectionbatch[0].sku ?? "") && o.comp_code == MasterEntity.comp_code && o.location_id == MasterEntity.location_Id && o.store_code == selectionbatch[0].store_code
//                                    select o);

//                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_S003_P)x).batch_no);
//                        TheFilter = (o, prefix) => (((MM_S003_P)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
//                        ASBatchItem = new AutoSuggestTextViewModel<dynamic>(temp.ToList(), TheFilter, SuggestedValue, "batch_no", "batch_no", true);
//                        ASBatchItem.AutoSuggestVM.IsEmptyValueAllowed = true;
//                    }
//                }

//            }
//            catch (Exception ex)
//            {

//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }

//        }
//        private void InsertDataGridRow_StoreLocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                MM_M001 POPUPEntityObject = null;

//                #region Command Parameter Read Section
//                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        {
//                            POPUPEntityObject = store_temp_list.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                        }
//                        catch (Exception ex) { }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
//                    }
//                }

//                #endregion

//                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
//                {
//                    ItemsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;

//                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
//                    {
//                        ItemsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;
//                    }
//                }




//            }
//            catch (Exception ex)
//            {

//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }


//        }
//        private void InsertDataGridRow_Batch(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {

//                string Request = "";
//                MM_S003_P POPUPEntityObject = null;

//                #region Command Parameter Read Section
//                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        {
//                            POPUPEntityObject = MC.batchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.ItemCode.Equals(ItemsEntity[dgSelectedIndexItem].ItemCode) == true).ToList()[0];
//                        }
//                        catch (Exception ex) { }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
//                    }
//                }

//                #endregion

//                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
//                {
//                    //var InputValueIfExists = ItemsEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
//                    //int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

//                    if (ItemsEntity.Count > dgSelectedIndexItem && POPUPEntityObject.batch_no.Trim() != "")
//                    {
//                        //if (IndexOfExistValue == -1)
//                        //{
//                        ItemsEntity[dgSelectedIndexItem].batch_no = POPUPEntityObject.batch_no;
//                        ItemsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;
//                        ItemsEntity[dgSelectedIndexItem].location_Id = POPUPEntityObject.location_id;
//                        ItemsEntity[dgSelectedIndexItem].comp_code = POPUPEntityObject.comp_code;
//                        //}
//                        //else if (IndexOfExistValue >= 0 && POPUPEntityObject.batch_no.Trim() != "")
//                        //{
//                        //    ItemsEntity[dgSelectedIndexItem].batch_no = "";
//                        //}

//                    }
//                }
//            }
//            catch (Exception ex)
//            {

//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }

//        }
//        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
//        {
//            try
//            {
//                string Request = "";
//                string ParametersStringValue = "";
//                MM_T003Flip ParameterEntityObject = null;
//                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
//                {
//                    if (ParameterReference == "DocumentNumber")
//                    {
//                        ParametersStringValue = ParameterObject.ToString().Trim();
//                    }

//                    if (ParametersStringValue.Length > 0)
//                    {
//                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue;
//                    }
//                }
//                if (ParameterObject != null)
//                {
//                    if (((IEnumerable)ParameterObject).Cast<MM_T003Flip>().ToList().Count > 0)
//                    {
//                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T003Flip>().ToList()[0];
//                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.req_no;
//                        isNewRecord = false;
//                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "", 0, Request);
//                        if (MCTemp.MasterEntity.Count > 0)
//                        {
//                            MasterEntity = MCTemp.MasterEntity[0];
//                            MasterEntity.ts_code = ts_code_vm;
//                        }
//                        else
//                        {
//                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                            showMessageService.ButtonSetup = DialogButton.Ok;
//                            showMessageService.Caption = "Message";
//                            showMessageService.Text = String.Format("This Record is Inactive....");
//                            showMessageService.ShowMessage();
//                        }
//                        ItemsEntity = MCTemp.ItemsEntity;
//                        SelectedTabControlIndex = 0;
//                        parameter = false;
//                    }
//                }
//                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
//                var msg = new NotificationMessage(ts_code_vm);
//                Messenger.Default.Send<NotificationMessage>(msg);
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void InsertBOM(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                ENG_T001_P POPUPEntityObject = null;
//                #region Command Parameter Read Section
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.BOMData.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
//                }
//                #endregion

//                if (POPUPEntityObject != null)
//                {
//                    MasterEntity.bom_no = POPUPEntityObject.doc_no;
//                    MasterEntity.order_qty = 1;
//                }
//            }
//            catch (Exception ex)
//            { }
//        }
//        private void ExecuteReference()
//        {
//            if (!string.IsNullOrWhiteSpace(MasterEntity.req_ref) && !string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MasterEntity.order_qty.HasValue)
//            {
//                MC_MM_T001 MCTempGRN = new MC_MM_T001();
//                WebServiceRepository<MC_MM_T001> repositoryMG = new WebServiceRepository<MC_MM_T001>();
//                string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + "MI" + "!@" + MasterEntity.req_ref + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.order_qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
//                MCTempGRN = repositoryMG.GetDataWithReturnDomainObject<MC_MM_T001>(MCTempGRN, Request, "MM_T001_STD", "SCM", "LoadAll", 0, "");
//                MasterEntity.ts_code = ts_code_vm;

//                ItemsEntity.Clear();
//                foreach (var obj in MCTempGRN.ItemDetailsList)
//                {
//                    MM_T003_A item = new MM_T003_A();
//                    item.doc_cat = "IO";
//                    item.doc_type = "IO";
//                    item.location_Id = MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id;
//                    item.comp_code = MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code;
//                    item.add_by = AppSessionState.UserID;
//                    item.editby = AppSessionState.UserID;
//                    item.active = true;
//                    item.t_status = "01";
//                    item.order_no = MasterEntity.req_ref;
//                    item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
//                    item.active = true;
//                    item.appr_qty = 0;
//                    item.ItemCode = obj.ItemCode;
//                    item.description = obj.description;
//                    item.item_cat = "A";
//                    item.line_id = ItemsEntity.Count + 1;
//                    item.order_no = obj.order_no;
//                    item.qty = obj.qty;
//                    item.sku = obj.sku;
//                    item.sku_desc = obj.sku_desc;
//                    item.store_code = obj.store_code;
//                    item.ts_code = this.ts_code_vm;
//                    item.unit_code = obj.unit_code;
//                    item.userid = AppSessionState.UserID;

//                    ItemsEntity.Add(item);

//                }
//            }
//        }
//        private void InsertDocType(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                SYS_M011_P POPUPEntityObject = null;
//                #region Command Parameter Read Section

//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.DocType.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M011_P>().ToList()[0];
//                }
//                #endregion             
//                if (POPUPEntityObject != null)
//                {
//                    MasterEntity.doc_type = POPUPEntityObject.doc_type_user;
//                    MasterEntity.doc_desc_user = POPUPEntityObject.doc_desc_user;
//                }
//            }
//            catch (Exception ex)
//            { }
//        }
//        private void InsertPriority(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                ADM_M040_P POPUPEntityObject = null;
//                #region Command Parameter Read Section     
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.PrioritiesList.Where(x => x.priority.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M040_P>().ToList()[0];
//                }
//                #endregion
//                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
//                if (POPUPEntityObject != null)
//                {
//                    MasterEntity.priority = POPUPEntityObject.id;
//                    MasterEntity.priorityNm = POPUPEntityObject.priority;
//                }
//            }
//            catch (Exception ex)
//            { }
//        }
//        private void InsertRequster(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                ADM_M024_P POPUPEntityObject = null;
//                #region Command Parameter Read Section     
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.RequsterList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
//                }
//                #endregion
//                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
//                if (POPUPEntityObject != null)
//                {
//                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
//                    MasterEntity.Requester_Nm = POPUPEntityObject.EmpName;
//                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
//                    MasterEntity.Dept_Name = POPUPEntityObject.DeptName;
//                }
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        private void InsertDeptment(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                ADM_M025_P POPUPEntityObject = null;
//                #region Command Parameter Read Section            
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.DeptList.Where(x => x.dept_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
//                }
//                #endregion
//                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
//                if (POPUPEntityObject != null)
//                {
//                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
//                    MasterEntity.Dept_Name = POPUPEntityObject.DeptName;
//                }
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                ADM_M022_P POPUPEntityObject = null;
//                dgSelectedIndexItem = dgSelectedIndexItem;
//                #region Command Parameter Read Section
//                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
//                }
//                #endregion

//                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
//                {
//                    var InputValueIfExists = ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
//                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

//                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
//                    {
//                        ItemsEntity.Add(new MM_T003_A()
//                        {
//                            ItemCode = POPUPEntityObject.ItemCode,
//                            description = POPUPEntityObject.ItemName,
//                            unit_code = POPUPEntityObject.unit_code,
//                            SubCatCode = POPUPEntityObject.SubCatCode,
//                            StockUnt = POPUPEntityObject.StockUnt,
//                            location_Id = MasterEntity.location_Id,
//                            store_code = store_location,
//                            comp_code = MasterEntity.comp_code,
//                            sku = POPUPEntityObject.sku,
//                            sku_desc = POPUPEntityObject.sku_desc,
//                            add_by = AppSessionState.UserID,
//                            active = true,
//                            t_status = "01",
//                            order_no = MasterEntity.req_ref,
//                            doc_cat = MasterEntity.doc_cat,
//                            doc_type = MasterEntity.doc_type,
//                            userid = AppSessionState.UserID,
//                            t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault()

//                        });
//                    }
//                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
//                        {
//                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
//                            ItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
//                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
//                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
//                            ItemsEntity[dgSelectedIndexItem].sku_desc = POPUPEntityObject.sku_desc;
//                            ItemsEntity[dgSelectedIndexItem].sku = POPUPEntityObject.sku;
//                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
//                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
//                            ItemsEntity[dgSelectedIndexItem].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
//                            ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
//                            ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.OBJ_LOCATION.location_id;
//                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
//                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
//                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
//                            ItemsEntity[dgSelectedIndexItem].active = true;
//                            ItemsEntity[dgSelectedIndexItem].t_status = "01";
//                            ItemsEntity[dgSelectedIndexItem].order_no = MasterEntity.req_ref;
//                            ItemsEntity[dgSelectedIndexItem].doc_cat = MasterEntity.doc_cat;
//                            ItemsEntity[dgSelectedIndexItem].doc_type = MasterEntity.doc_type;
//                            ItemsEntity[dgSelectedIndexItem].userid = AppSessionState.UserID;
//                            ItemsEntity[dgSelectedIndexItem].t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

//                        }
//                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
//                            ItemsEntity[dgSelectedIndexItem].description = "";
//                        }
//                    }
//                }
//                #region Clear Empty Row
//                MM_T003_A newObj = new MM_T003_A();
//                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
//                {
//                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
//                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
//                    {
//                        ItemsEntity.RemoveAt(i);
//                        if (ItemsEntity.Count == 0)
//                        {
//                            ItemsEntity.Add(newObj);
//                        }
//                    }
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void InsertItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                SYS_M008_P POPUPEntityObject = null;
//                dgSelectedIndexItem = dgSelectedIndexItem;
//                #region Command Parameter Read Section
//                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.ItemCategoryList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<SYS_M008_P>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M008_P>().ToList()[0];
//                    }
//                }

//                #endregion

//                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
//                {
//                    var InputValueIfExists = ItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
//                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

//                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
//                        {
//                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
//                        }
//                        else if (ItemsEntity[dgSelectedIndexItem].item_cat != POPUPEntityObject.item_cat)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].item_cat = "";
//                        }
//                    }
//                }
//                #region Clear Empty Row
//                MM_T003_A newObj = new MM_T003_A();
//                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
//                {
//                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
//                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
//                    {
//                        ItemsEntity.RemoveAt(i);
//                        if (ItemsEntity.Count == 0)
//                        {
//                            ItemsEntity.Add(newObj);
//                        }
//                    }
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                ADM_M038_B_P POPUPEntityObject = null;
//                #region Command Parameter Read Section
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
//                    }

//                }
//                #endregion
//                if (POPUPEntityObject != null)
//                {
//                    var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
//                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
//                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
//                        {
//                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
//                        }
//                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
//                        }
//                    }
//                }
//                #region Clear Empty Row
//                MM_T003_A newObj = new MM_T003_A();
//                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
//                {
//                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
//                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
//                    {
//                        ItemsEntity.RemoveAt(i);
//                        if (ItemsEntity.Count == 0)
//                        {
//                            ItemsEntity.Add(newObj);
//                        }
//                    }
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        private void Post()
//        {
//            try
//            {
//                if (MasterEntity.t_status == "11" || MasterEntity.t_status == "11")
//                {
//                    string reader = repositoryStr.Update<string>(MasterEntity.req_no, "MM_T003_BL_STS", "MM");

//                    int intreader = Convert.ToInt32(reader);

//                    if (intreader >= 0)
//                    {
//                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                        showMessageService.ButtonSetup = DialogButton.Ok;
//                        showMessageService.Caption = "Message";
//                        showMessageService.Text = String.Format("Status Update Sucessful", this.Title);
//                        showMessageService.ShowMessage();
//                        post = false;
//                        //If Post is Sucessful status is updated else not
//                        MasterEntity.t_status = "03";
//                        MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

//                    }
//                }
//                else
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Message";
//                    showMessageService.Text = String.Format("Status is not Shipped", this.Title);
//                    showMessageService.ShowMessage();
//                    post = true;
//                }
//            }
//            catch (Exception ex)
//            { }
//        }
//        private void CloseIndentForcefully()
//        {
//            try
//            {
//                if (MasterEntity.req_no != null && MasterEntity.req_no != "")
//                {
//                    if (MasterEntity.t_status == "16" || MasterEntity.t_status == "01")
//                    {
//                        string Request = MasterEntity.req_no + "!@" + "Close Indent";
//                        string reader = repositoryStr.Update<string>(Request, "MM_T003_BL_STS", "MM");
//                        int intreader = Convert.ToInt32(reader);
//                        if (intreader >= 0)
//                        {
//                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                            showMessageService.ButtonSetup = DialogButton.Ok;
//                            showMessageService.Caption = "Message";
//                            showMessageService.Text = String.Format("Indent Closed By User", this.Title);
//                            showMessageService.ShowMessage();
//                            MasterEntity.t_status = "03";
//                            MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

//                        }
//                    }
//                    else
//                    {
//                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                        showMessageService.ButtonSetup = DialogButton.Ok;
//                        showMessageService.Caption = "Message";
//                        showMessageService.Text = String.Format("Only partially Shipped orders close forcefully", this.Title);
//                        showMessageService.ShowMessage();
//                    }
//                }
//                else
//                {
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Message";
//                    showMessageService.Text = String.Format("Please Select Order No", this.Title);
//                    showMessageService.ShowMessage();
//                }
//            }
//            catch (Exception ex)
//            { }
//        }
//        private void InsertMachine(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                ZADM_M013_P POPUPEntityObject = null;
//                #region Command Parameter Read Section
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<ZADM_M013_P>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
//                    }
//                }
//                #endregion
//                if (POPUPEntityObject != null)
//                {
//                    var InputValueIfExists = MC.MachineList.Where(x => x.machinecode == POPUPEntityObject.machinecode).FirstOrDefault();
//                    var IndexOfExistValue = MC.MachineList.IndexOf(MC.MachineList.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault());
//                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
//                        {
//                            ItemsEntity[dgSelectedIndexItem].machinecode = POPUPEntityObject.machinecode;
//                        }
//                        else if (ItemsEntity[dgSelectedIndexItem].machinecode != POPUPEntityObject.machinecode)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].machinecode = POPUPEntityObject.machinecode;
//                        }
//                    }
//                }
//                #region Clear Empty Row
//                MM_T003_A newObj = new MM_T003_A();
//                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
//                {
//                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
//                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
//                    {
//                        ItemsEntity.RemoveAt(i);
//                        if (ItemsEntity.Count == 0)
//                        {
//                            ItemsEntity.Add(newObj);
//                        }
//                    }
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        private void InsertOrder(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
//        {
//            try
//            {
//                string Request = "";
//                EPR_T001_P POPUPEntityObject = null;
//                #region Command Parameter Read Section
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        POPUPEntityObject = MC.OrderList.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    if (((IEnumerable)InputValue).Cast<EPR_T001_P>().Count() > 0)
//                    {
//                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P>().ToList()[0];
//                    }
//                }
//                #endregion
//                if (POPUPEntityObject != null)
//                {
//                    var InputValueIfExists = MC.OrderList.Where(x => x.order_no == POPUPEntityObject.order_no).FirstOrDefault();
//                    var IndexOfExistValue = MC.OrderList.IndexOf(MC.OrderList.Where(X => X.order_no == POPUPEntityObject.order_no).FirstOrDefault());
//                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
//                        {
//                            ItemsEntity[dgSelectedIndexItem].order_no = POPUPEntityObject.order_no;
//                            ItemsEntity[dgSelectedIndexItem].machinecode = POPUPEntityObject.machinecode;

//                        }
//                        else if (ItemsEntity[dgSelectedIndexItem].machinecode != POPUPEntityObject.machinecode)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].order_no = POPUPEntityObject.order_no;
//                            ItemsEntity[dgSelectedIndexItem].machinecode = POPUPEntityObject.machinecode;
//                        }
//                    }
//                }
//                #region Clear Empty Row
//                MM_T003_A newObj = new MM_T003_A();
//                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
//                {
//                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
//                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
//                    {
//                        ItemsEntity.RemoveAt(i);
//                        if (ItemsEntity.Count == 0)
//                        {
//                            ItemsEntity.Add(newObj);
//                        }
//                    }
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void DeleteDataGridRow_Item(object InputValue)
//        {
//            try
//            {
//                int i = (int)InputValue;
//                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
//                {
//                    ItemsEntity.RemoveAt(i);
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void CollectionChanged(object DataList)
//        {
//            string[] TempSkuList = new string[100];
//            List<string> TempParaValueList = new List<string>();
//            IList list = DataList as IList;
//            int a = dgSelectedIndexItem;
//            try
//            {
//                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
//                {
//                    List<MM_T003_A> SelectedRowlist = list.Cast<MM_T003_A>().ToList();

//                    if (SelectedRowlist[0].StockUnt == true)
//                    {
//                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();

//                        ParameterTemp = paramlist.ToList();

//                        if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
//                        {
//                            TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

//                            for (int i = 0; i < paramlist.Count; i++)
//                            {
//                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
//                                if (TempParaValueList.Count > 0)
//                                {
//                                    paramlist[i].parametervalue = TempParaValueList[0];
//                                }
//                            }

//                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
//                        }
//                        else
//                        {
//                            foreach (var o in ParameterTemp)
//                            {
//                                o.parametervalue = null; o.value_code = null;
//                            }
//                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
//                        }

//                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
//                        {
//                            SelectedParaValueCollection = new List<ADM_M031_P>();

//                            for (int i = 0; i < paramlist.Count; i++)
//                            {
//                                SelectedParaValueCollection.Add(new ADM_M031_P()
//                                {

//                                    dgselectedindex = dgSelectedIndexItem,
//                                    para_code = paramlist[i].para_code,
//                                    para_name = paramlist[i].para_name

//                                });
//                            }
//                            if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
//                            {
//                                SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

//                                foreach (var o in SelectedParaValueCollection)
//                                {
//                                    o.dgselectedindex = dgSelectedIndexItem;
//                                    foreach (var p in MC.ParamValueList)
//                                    {
//                                        if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
//                                        {
//                                            o.value_code = p.value_code;
//                                        }
//                                    }
//                                }
//                            }

//                        }
//                    }
//                }
//                else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
//                { }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void GetSelectedParaValue(IList parameter)
//        {
//            try
//            {
//                IList list = parameter as IList;
//                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
//                int a = ParadgSelectedIndex;
//                int b = dgSelectedIndexItem;
//                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
//                {
//                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
//                    {
//                        #region 
//                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
//                        {
//                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
//                            {
//                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex <= dgSelectedIndexItem)
//                                {
//                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

//                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

//                                    if (paravaluetemp.Count > 0)
//                                    {
//                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
//                                    }
//                                }
//                            }
//                            // SKU Description
//                            GetSkuDescription();
//                            //Function for calculating SKU
//                            CalculateSku();
//                        }
//                        #endregion
//                    }
//                    else if (ItemsEntity[dgSelectedIndexItem].id != 0)
//                    {
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void GetSkuDescription()
//        {
//            try
//            {
//                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
//                {
//                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
//                    {
//                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
//                        }
//                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
//                        }
//                    }
//                }
//                else
//                {
//                    ItemsEntity[dgSelectedIndexItem].sku_desc = "";

//                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
//                    {
//                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
//                        }
//                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void CalculateSku()
//        {
//            try
//            {
//                if (ItemsEntity[dgSelectedIndexItem].sku == null || ItemsEntity[dgSelectedIndexItem].sku == "")
//                {
//                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
//                        }
//                        else
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
//                        }
//                    }
//                }
//                else
//                {
//                    ItemsEntity[dgSelectedIndexItem].sku = "";

//                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
//                        }
//                        else
//                        {
//                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void GetselectedSkuParameter(Object InputList)
//        {
//            IList list = InputList as IList;
//            try
//            {
//                if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
//                {
//                    List<MM_T003_A> selectedlist = list.Cast<MM_T003_A>().ToList();

//                    if (ItemsEntity.Count > 0)
//                    {
//                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
//                        {
//                            parameter = true;
//                        }
//                        else
//                        {
//                            parameter = false;
//                        }
//                    }
//                }

//                batchSelection(list);
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void WindowEvetCall(object InputValue)
//        {
//            try
//            {
//                if (doc_no_vm != null && ts_code_vm != null)
//                {
//                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");

//                    AppSessionState.ViewOtherRecordAllowed = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        private void Invoke_Reference_Document(object InputValue)
//        {
//            try
//            {
//                string Request = "";
//                ReflectionFunctionService objRef = new ReflectionFunctionService();
//                #region Command Parameter Read Section

//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
//                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
//                    objRef.Invoke_Documet(Request, Request);
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            { }
//        }
//        #endregion

//        #region Abstract Method
//        protected override void OnCreateAction(InquiryActionResult<PMS_T001> result)
//        {
//            isNewRecord = true;
//            MasterEntity = new PMS_T001();
//            MasterEntity.ValidateAsync().Wait();
//            ItemsEntity = new ObservableCollection<MM_T003_A>();
//            ItemsEntity.Clear();
//            DefaultValues();

//            var msg = new NotificationMessage("MM_T003_VM");
//            Messenger.Default.Send<NotificationMessage>(msg);
//        }
//        protected override void OnDiscardAction(InquiryActionResult<PMS_T001> result)
//        { }
//        protected override void OnFevoriteAction(InquiryActionResult<PMS_T001> result)
//        { }
//        protected override void OnFlipAction(InquiryActionResult<PMS_T001> result)
//        { }
//        protected override void OnHelpAction(InquiryActionResult<PMS_T001> result)
//        { }
//        protected override void OnPrintAction(InquiryActionResult<PMS_T001> result)
//        {
//            CursorControl.SetBusyState();

//            try
//            {

//                string Request = "LoadDocumentWithDocumentNumber" + "!@" + MasterEntity.req_no;

//                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "LoadDocumentWithDocumentNumber", 0, "");

//                object[] objDataSource = new object[4];
//                string[] objDataSourceName = new string[4];

//                //MCTemp.MasterEntity.Clear();
//                //MCTemp.MasterEntity.Add(MasterEntity);

//                objDataSource[0] = MCTemp.MasterEntity;
//                objDataSource[1] = MCTemp.ItemsEntity;

//                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
//                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
//                objDataSource[2] = CmpResult;

//                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
//                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
//                objDataSource[3] = Result;



//                objDataSourceName[0] = "dsIndentMaster";
//                objDataSourceName[1] = "dsIndentItems";
//                objDataSourceName[2] = "dsCompany";
//                objDataSourceName[3] = "dsLocation";


//                ReportManager ReportManager = new ReportManager();
//                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\Indent.rdlc", "");
//            }
//            catch (Exception ex) { }
//        }
//        protected override void OnRemoveAction(InquiryActionResult<PMS_T001> result)
//        {
//            try
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Delete Changes";
//                showMessageService.Text =
//                    String.Format(
//                        "This record will be Deleted forever '{0}'",
//                            this.Title);
//                if (showMessageService.ShowMessage() == DialogResult.Ok)
//                {
//                    this.MasterEntity.EndEdit();
//                    string response = repository.Delete(MasterEntity.req_no, "MM_T003_BL", "MM");
//                    MasterEntity = new PMS_T001();
//                    ItemsEntity = new ObservableCollection<MM_T003_A>();
//                    _dataGridCollection.Refresh();
//                    isNewRecord = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        protected override void OnSaveAction(InquiryActionResult<PMS_T001> result)
//        {
//            try
//            {
//                //if (Mouse.OverrideCursor == null)
//                //{
//                //    CursorControl.SetBusyState();
//                if (Validation() == true)
//                {
//                    MasterEntity.XmlDataDocument_MM_T003_A = obj.ObjectToXML(ItemsEntity);
//                    //MasterEntity.user_source1 = AppSessionState.UserSource1;
//                    //MasterEntity.user_source2 = AppSessionState.UserSource2;
//                    this.MasterEntity.EndEdit();
//                    if (isNewRecord == true)
//                    {
//                        MasterEntity = repository.SaveWithReturnDomainObject<PMS_T001>(MasterEntity, "MM_T003_BL", "MM");
//                        if (MasterEntity.req_no != " " || MasterEntity.req_no != null)
//                        {
//                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                            showMessageService.ButtonSetup = DialogButton.Ok;
//                            showMessageService.Caption = "Message";
//                            showMessageService.Text = String.Format("Data Saved Successfully");
//                            showMessageService.ShowMessage();
//                        }
//                    }
//                    else if (isNewRecord == false)
//                    {
//                        MasterEntity = repository.UpdateWithReturnDomainObject<PMS_T001>(MasterEntity, "MM_T003_BL", "MM");
//                        if (MasterEntity.req_no != " " || MasterEntity.req_no != null)
//                        {
//                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                            showMessageService.ButtonSetup = DialogButton.Ok;
//                            showMessageService.Caption = "Message";
//                            showMessageService.Text = String.Format("Data Update Successfully");
//                            showMessageService.ShowMessage();
//                        }
//                    }
//                    SetBusinessEntitiesAfterLoad("Save", "");
//                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
//                }
//                //}
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        protected override void OnDocumentAction()
//        { }
//        protected override void OnRefreshCommand(InquiryActionResult<PMS_T001> result)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void OnLedgerViewCommand(InquiryActionResult<PMS_T001> result)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void OnValidateCommand(InquiryActionResult<PMS_T001> result)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void OnTraceCommand(InquiryActionResult<PMS_T001> result)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void OnMailCommand(InquiryActionResult<PMS_T001> result)
//        {
//            throw new NotImplementedException();
//        }

//        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
//        {
//            try
//            {
//                MasterEntity.ts_code = ts_code_vm;
//                if (MasterEntity.XmlDataDocument_MM_T003_A != null)
//                {
//                    ItemsEntity.Clear();
//                    ItemsEntity = (ObservableCollection<MM_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T003_A, MC.ItemsEntity);
//                    MasterEntity = MasterEntity;
//                }
//                else
//                {
//                    MC.ItemsEntity = new ObservableCollection<MM_T003_A>();
//                }
//                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
//                {
//                    MC.DocumentDataFlipGrid = (List<MM_T003Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
//                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
//                    DataGridCollection.Refresh();
//                    DataGridCollection.SortDescriptions.Add(new SortDescription("req_no", ListSortDirection.Descending));
//                }
//            }
//            catch (Exception ex)
//            {
//                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                //showMessageService.ButtonSetup = DialogButton.Ok;
//                //showMessageService.Caption = "Message";
//                //showMessageService.Text = String.Format(ex.Message, this.Title);
//                //showMessageService.ShowMessage();
//            }
//        }
//        #endregion
//        #region Filter
//        private string _filterString_FlipGrid;
//        public string FilterString_FlipGrid
//        {
//            get { return _filterString_FlipGrid; }
//            set
//            {
//                _filterString_FlipGrid = value;
//                RaisePropertyChanged("FilterString_FlipGrid");
//                FilterCollection_FlipGrid();
//            }
//        }
//        private void FilterCollection_FlipGrid()
//        {
//            if (_dataGridCollection != null)
//            {
//                _dataGridCollection.Refresh();
//            }
//        }
//        public bool Filter_FlipGrid(object obj)
//        {
//            var data = obj as MM_T003Flip;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
//                {
//                    return (data.req_no != null && data.req_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                        (data.date_start != null && data.date_start.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                    (data.Requester_Nm != null && data.Requester_Nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                    (data.priorityNm != null && data.priorityNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                    (data.Dept_Name != null && data.Dept_Name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                     (data.deadline != null && data.deadline.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                    (data.req_type != null && data.req_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
//                    (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        private string _FilterStringBOM;
//        public string FilterStringBOM
//        {
//            get { return _FilterStringBOM; }
//            set
//            {
//                _FilterStringBOM = value;
//                RaisePropertyChanged("FilterStringBOM");
//                FilterBOMCollection();
//            }
//        }
//        private void FilterBOMCollection()
//        {
//            if (_BomCollection != null)
//            {
//                _BomCollection.Refresh();
//            }
//        }
//        public bool FilterBOM(object obj)
//        {
//            var data = obj as ENG_T001_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_FilterStringBOM))
//                {
//                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringBOM.ToLower())) ||
//                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterStringBOM.ToLower())) ||
//                    (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterStringBOM.ToLower()));

//                }
//                return true;
//            }
//            return false;
//        }

//        private void FilterCollectionPriority()
//        {
//            if (_PriorityCollection != null)
//            {
//                _PriorityCollection.Refresh();
//            }
//        }
//        private string _filterStringPriority;
//        public string FilterStringPriority
//        {
//            get { return _filterStringPriority; }
//            set
//            {
//                _filterStringPriority = value;
//                RaisePropertyChanged("FilterStringPriority");
//                FilterCollectionPriority();
//            }
//        }
//        public bool PriorityFilter(object obj)
//        {
//            var data = obj as ADM_M040_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterStringPriority))
//                {
//                    return (data.priority != null && data.priority.ToString().ToLower().Contains(_filterStringPriority.ToLower()));

//                }
//                return true;
//            }
//            return false;
//        }
//        private string _filterStringRequester;
//        private void FilterCollectionRequester()
//        {
//            if (_RequesterCollection != null)
//            {
//                _RequesterCollection.Refresh();
//            }
//        }
//        public string FilterStringRequester
//        {
//            get { return _filterStringRequester; }
//            set
//            {
//                _filterStringRequester = value;
//                RaisePropertyChanged("FilterStringRequester");
//                FilterCollectionRequester();
//            }
//        }
//        public bool Filterrequest(object obj)
//        {
//            var data = obj as ADM_M024_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterStringRequester))
//                {
//                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringRequester.ToLower()) ||
//                             data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringRequester.ToLower()));


//                }
//                return true;
//            }
//            return false;
//        }
//        private string _filterStringDepartment;
//        private void FilterCollectionDepartment()
//        {
//            if (_DepartmentCollection != null)
//            {
//                _DepartmentCollection.Refresh();
//            }
//        }
//        public string FilterStringDepartment
//        {
//            get { return _filterStringDepartment; }
//            set
//            {
//                _filterStringDepartment = value;
//                RaisePropertyChanged("FilterStringDepartment");
//                FilterCollectionDepartment();
//            }
//        }
//        public bool FilterDept(object obj)
//        {
//            var data = obj as ADM_M025_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterStringDepartment))
//                {
//                    return (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringDepartment.ToLower()) ||
//                            data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringDepartment.ToLower()));

//                }
//                return true;
//            }
//            return false;
//        }
//        private void FilterCollectionItems()
//        {
//            if (_ItemsCollection != null)
//            {
//                _ItemsCollection.Refresh();
//            }
//        }
//        private string _filterStringItems;
//        public string FilterStringItems
//        {
//            get { return _filterStringItems; }
//            set
//            {
//                _filterStringItems = value;
//                RaisePropertyChanged("FilterStringItems");
//                FilterCollectionItems();
//            }
//        }
//        public bool ItemsFilter(object obj)
//        {
//            var data = obj as ADM_M022_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterStringItems))
//                {
//                    return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringItems.ToLower())) ||
//                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
//                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
//                           (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterStringItems.ToLower()));

//                }
//                return true;
//            }
//            return false;
//        }
//        private string _filterString_itemcategory;
//        public string FilterString_itemcategory
//        {
//            get { return _filterString_itemcategory; }
//            set
//            {
//                _filterString_itemcategory = value;
//                RaisePropertyChanged("FilterString_itemcategory");
//                FilterCollectionitemcategory();
//            }
//        }
//        private void FilterCollectionitemcategory()
//        {
//            if (_itemcategoryCollection != null)
//            {
//                _itemcategoryCollection.Refresh();
//            }
//        }
//        public bool Filteritemcategory(object obj)
//        {
//            var data = obj as SYS_M008_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_itemcategory))
//                {
//                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
//                        data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }

//        private string _filterString_UOM;
//        public string FilterString_UOM
//        {
//            get { return _filterString_UOM; }
//            set
//            {
//                _filterString_UOM = value;
//                RaisePropertyChanged("FilterString_UOM");
//                FilterCollection_UOM();
//            }
//        }
//        private void FilterCollection_UOM()
//        {
//            if (_uomCollection != null)
//            {
//                _uomCollection.Refresh();
//            }
//        }
//        public bool Filter_UOM(object obj)
//        {
//            var data = obj as ADM_M038_B_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_UOM))
//                {
//                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
//                          data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }

//        private string _FilterStringMachine;
//        public string FilterStringMachine
//        {
//            get { return _FilterStringMachine; }
//            set
//            {
//                _FilterStringMachine = value;
//                RaisePropertyChanged("FilterStringMachine");
//                FilterCollection_Machine();
//            }
//        }
//        private void FilterCollection_Machine()
//        {
//            if (_MachineCollection != null)
//            {
//                _MachineCollection.Refresh();
//            }
//        }
//        public bool Filter_Machine(object obj)
//        {
//            var data = obj as ZADM_M013_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_FilterStringMachine))
//                {
//                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringMachine.ToLower()) ||
//                          data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_FilterStringMachine.ToLower()) ||
//                          data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_FilterStringMachine.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }

//        private string _FilterStringDocType;
//        public string FilterStringDocType
//        {
//            get { return _FilterStringDocType; }
//            set
//            {
//                _FilterStringDocType = value;
//                RaisePropertyChanged("FilterStringDocType");
//                FilterCollection_DocType();
//            }
//        }
//        private void FilterCollection_DocType()
//        {
//            if (_DocTypeCollection != null)
//            {
//                _DocTypeCollection.Refresh();
//            }
//        }
//        public bool Filter_DocType(object obj)
//        {
//            var data = obj as SYS_M011_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_FilterStringDocType))
//                {
//                    return (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_FilterStringDocType.ToLower()) ||
//                          data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_FilterStringDocType.ToLower()) ||
//                          data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterStringDocType.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }

//        private string _FilterStringOrderNo;
//        public string FilterStringOrderNo
//        {
//            get { return _FilterStringOrderNo; }
//            set
//            {
//                _FilterStringOrderNo = value;
//                RaisePropertyChanged("FilterStringOrderNo");
//                FilterStringOrderNoCollection();
//            }
//        }
//        private void FilterStringOrderNoCollection()
//        {
//            if (_OrderNoCollection != null)
//            {
//                _OrderNoCollection.Refresh();
//            }
//        }
//        public bool FilterOrderNo(object obj)
//        {
//            var data = obj as EPR_T001;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_FilterStringOrderNo))
//                {
//                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterStringOrderNo.ToLower()) ||
//                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringOrderNo.ToLower()) ||
//                            data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringOrderNo.ToLower())
//                        );

//                }
//                return true;
//            }
//            return false;
//        }


//        #endregion

//    }
//}
