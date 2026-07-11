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
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Production.ViewModels
{
    class MM_T001_WIP_ConsumptionVM : WorkspaceViewModel<MM_T001>
    {
        #region AutoSuggest Initialization

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
                    { }
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
        public AutoSuggestTextViewModel<dynamic> ASplant
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

        private AutoSuggestTextViewModel <dynamic> _ASStore { get; set; }
        public AutoSuggestTextViewModel <dynamic> ASStore
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


        #endregion

        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repositoryM = new WebServiceRepository<MC_MM_T001>();
        MC_MM_T001 MCTemp = new MC_MM_T001();
        ObjectSerializationService objSerialization = new ObjectSerializationService();
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
        private bool _MoveFlag;
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
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
        public RelayCommand<object> SelectionChangedCommandRequester{get;private set;}
        public RelayCommand<object> SelectionChangedCommandOrderDocNo{get;private set;}
        public RelayCommand<object> SelectionChangedCommandMovType{get;private set;}
        public RelayCommand<object> SelectionChangedCommandItem{get;private set;}
        public RelayCommand<object> SelectionChangedCommandUnit{get;private set;}
        public RelayCommand<object> SelectionChangedCommandPlantA{get;private set;}
        public RelayCommand<object> SelectionChangedCommandStoreLocation{get;private set;}
        public RelayCommand<object> ParameterPopupCommand{get;private set;}
        public RelayCommand<object> CollectionChangedMethod{get;private set;}
        public RelayCommand<object> CollectionChangedMethodbatch{get;private set;}
        public RelayCommand<IList> SelectionChangedCommandGoodsIssueDetails{get;private set;}
        public RelayCommand<IList> CollectionChangedCommand{get;private set;}
        public RelayCommand<IList> SelectionChangedParaValCommand{get;private set;}
        public RelayCommand<object> DataGridRowDeleteCommand{get;private set;}
        public RelayCommand<object> DataGridRowDeleteCommandBatch{get;private set;}
        public RelayCommand<IList> batchSelectionCommand{get;private set;}
        public RelayCommand<object> SelectionChangedCommandbatch{get;private set;}
        public RelayCommand<object> SelectionChangedBatchDetailsCommand{get;private set;}
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand{get;private set;}
        public RelayCommand<object> SelectionChangedCommandMachine { get; private set; }
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
                    RaisePropertyChanged("SelectedItemList");  
                }
            }
        }
        
        #endregion

      
        #region Constructor
        public MM_T001_WIP_ConsumptionVM(string ts_code):
            base()
        {
            this.ts_code_vm = ts_code;
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

            
            LoadInitialData();
        }
        public MM_T001_WIP_ConsumptionVM(string ts_code,string doc_no) :
           base()
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


            LoadInitialData();
        }
        #endregion

        #region . User Defined Function.
        private void GetSelectedBatchForItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                MM_S003_P BatchDetails = new MM_S003_P();
                #region Command Parameter Read Section    
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    
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
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            item_line_id = 0,
                            sku = BatchDetails.sku,
                            fin_year = "16-17",
                            posting_period = "1",
                            active = true
                        });
                    }
                    else if (dgSelectedBatchindex >= 0 && BatchDetails.Select == true && dgBatchEntity.Count > dgSelectedBatchindex) 
                    {
                        if (dgBatchEntity[dgSelectedBatchindex].ItemCode == null && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) 
                        {
                            dgBatchEntity[dgSelectedBatchindex].ItemCode = BatchDetails.ItemCode;
                            dgBatchEntity[dgSelectedBatchindex].unit_code = GoodsIssueDetails[dgSelectedIndex].unit_code;
                            dgBatchEntity[dgSelectedBatchindex].batch_no = BatchDetails.batch_no;
                            dgBatchEntity[dgSelectedBatchindex].store_code = BatchDetails.store_code;
                            dgBatchEntity[dgSelectedBatchindex].qty = BatchDetails.stock_total;

                            dgBatchEntity[dgSelectedBatchindex].comp_code = AppSessionState.comp_code;
                            dgBatchEntity[dgSelectedBatchindex].client = AppSessionState.client;
                            dgBatchEntity[dgSelectedBatchindex].location_Id = AppSessionState.location_Id;
                            dgBatchEntity[dgSelectedBatchindex].add_by = AppSessionState.UserID;
                            dgBatchEntity[dgSelectedBatchindex].sku = BatchDetails.sku;
                            dgBatchEntity[dgSelectedBatchindex].fin_year = "16-17";
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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
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

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

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
                            client = AppSessionState.client,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "19-20",
                            line_id = GoodsIssueDetails.Count() + 1,
                            store_code = store_location,
                            debcr_ind = "N",
                            mat_con = "New",
                            active = true,
                            order_doc_no = MasterEntity.order_doc_no,

                        });
                    }

                    else if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) 
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            GoodsIssueDetails[dgSelectedIndex].ItemCode = POPUPEntityObject.ItemCode;
                            GoodsIssueDetails[dgSelectedIndex].description = POPUPEntityObject.ItemName;
                            GoodsIssueDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            GoodsIssueDetails[dgSelectedIndex].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                            GoodsIssueDetails[dgSelectedIndex].active = true;
                            GoodsIssueDetails[dgSelectedIndex].SubCatCode = POPUPEntityObject.SubCatCode;
                            GoodsIssueDetails[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            GoodsIssueDetails[dgSelectedIndex].client = AppSessionState.client;
                            GoodsIssueDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            GoodsIssueDetails[dgSelectedIndex].fin_year = "16-17";
                            GoodsIssueDetails[dgSelectedIndex].posting_period = "1";
                            GoodsIssueDetails[dgSelectedIndex].line_id = 0;
                            GoodsIssueDetails[dgSelectedIndex].store_code = store_location;
                            GoodsIssueDetails[dgSelectedIndex].qty = POPUPEntityObject.qty; 
                            GoodsIssueDetails[dgSelectedIndex].order_doc_no = MasterEntity.order_doc_no;
                            GoodsIssueDetails[dgSelectedIndex].debcr_ind = "N";
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
        private void InsertDataGridRow_Uom(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
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

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); 
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); 

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex)
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) 
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
               
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                   
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

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); 
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault());

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) 
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            GoodsIssueDetails[dgSelectedIndex].location_Id = POPUPEntityObject.location_Id;
                            GoodsIssueDetails[dgSelectedIndex].Plant_Name = POPUPEntityObject.LoctnNm;
                            GoodsIssueDetails[dgSelectedIndex].machinecode = "";

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
               
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                 
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

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault(); 
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault());

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) 
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) 
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
        private void InsertDataGridRow_StoreLocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M001 POPUPEntityObject = null;

                #region Command Parameter Read Section
                
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                
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

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault();
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); 

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) 
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
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
        private void InsertDataGridRow_Batch(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    
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

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = GoodsIssueDetails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault(); 
                    int IndexOfExistValue = GoodsIssueDetails.IndexOf(GoodsIssueDetails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); 

                    if (dgSelectedIndex >= 0 && GoodsIssueDetails.Count > dgSelectedIndex) 
                    {
                        if (GoodsIssueDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            
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
                                        comp_code = AppSessionState.comp_code,
                                        client = AppSessionState.client,
                                        location_Id = AppSessionState.location_Id,
                                        add_by = AppSessionState.UserID,
                                        posting_period = "1",
                                        fin_year = "16-17",
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
                                    dgBatchEntity[IndexOfrecord].comp_code = AppSessionState.comp_code;
                                    dgBatchEntity[IndexOfrecord].client = AppSessionState.client;
                                    dgBatchEntity[IndexOfrecord].location_Id = AppSessionState.location_Id;
                                    dgBatchEntity[IndexOfrecord].add_by = AppSessionState.UserID;
                                    dgBatchEntity[IndexOfrecord].sku = POPUPEntityObject.sku;
                                    dgBatchEntity[dgSelectedIndex].fin_year = "16-17";
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
                            string movtp = MasterEntity.mov_tp;
                            string movname = MasterEntity.mov_name;
                            MasterEntity = repository.GetDataWithReturnDomainObject<MM_T001>(MasterEntity, Request, "Goods_Issue", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                            MasterEntity.mov_tp = movtp;
                            MasterEntity.mov_name = movname;
                            MasterEntity.ts_code = ts_code_vm;
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


                if (ParametersStringValue == "ReferenceDocument")
                {
                    MasterEntity.ref_doc = MasterEntity.ref_doc;
                    MasterEntity.ref_doc_date = MasterEntity.doc_date;
                    MasterEntity.doc_cat = "WC";
                    MasterEntity.doc_type = "WC";
                    MasterEntity.doc_no = "";
                    MasterEntity.doc_date = DateTime.Now;
                    MasterEntity.post_date = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.fin_year = "16-17";
                    MasterEntity.posting_period = "1";
                    MasterEntity.active = true;
                    MasterEntity.t_status = "004";
                    MasterEntity.ts_code = ts_code_vm;

                }

                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
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

                        if (paramlist.Count > 0) 
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
                }
                else if (GoodsIssueDetails[dgSelectedIndex].id != 0 && GoodsIssueDetails.Count > 0 && dgSelectedIndex < GoodsIssueDetails.Count)
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

                            GetSkuDescription();
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
                if (GoodsIssueDetails[dgSelectedIndex].sku == null || GoodsIssueDetails[dgSelectedIndex].sku == "")
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
                else
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
                    LoadDocumentByDocumentNumber(doc_no_vm);
                    
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

        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "WC";
                MasterEntity.doc_type = "WC";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@"+MasterEntity.editby +"!@" + AppSessionState.UserID;
                MC = repositoryM.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "Goods_Issue", "SCM", Request, 0, "LoadInitialData");

                #region Command Initialisation
                SelectionChangedCommandRequester = new RelayCommand<object>(items => { if (items == null) { return; } InsertRequster(items); });
                //SelectionChangedCommandMovType = new RelayCommand<object>(items => {if (items == null) { return; }InsertMovementType(items);});
                SelectionChangedCommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                SelectionChangedCommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Uom(cmdPara, false, true, true); });
                SelectionChangedCommandStoreLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });
                SelectionChangedCommandPlantA = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Plant(cmdPara, false, true, true); });
                SelectionChangedCommandbatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Batch(cmdPara, false, true, true); });
                SelectionChangedCommandOrderDocNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrderNoList(items); });
                DataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                DataGridRowDeleteCommandBatch = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_ItemBatch(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                batchSelectionCommand = new RelayCommand<IList>(items => { if (items == null) { return; } batchSelection(items); });
                SelectionChangedBatchDetailsCommand = new RelayCommand<object>(Items => { if (Items == null) { return; } GetSelectedBatchForItem(Items, true, false, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
                SelectionChangedCommandMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_MachineCode(cmdPara, false, true, true); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToLower().Contains(prefix) || ((ADM_M024_P)o).EmpName.ToLower().Contains(prefix);
                ASRequester = new AutoSuggestTextViewModel<dynamic>(MC.Requster, TheFilter, SuggestedValue, "EmpId", true);
                ASRequester.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix);
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.unitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => ((ZADM_M013_P)o).machinecode.ToLower().Contains(prefix);
                ASMachine = new AutoSuggestTextViewModel<dynamic>(MC.MachineCodeList, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                CollectionMovType = CollectionViewSource.GetDefaultView(MC.MovementTypeList);
                CollectionMovType.Filter = new Predicate<object>(FilterMovType);
                StringListMovement = MC.MovementTypeList.Select(x => x.mov_tp).ToList();

                CollectionRequester = CollectionViewSource.GetDefaultView(MC.Requster);
                CollectionRequester.Filter = new Predicate<object>(Filterrequest);
                StringListRequster = MC.Requster.Select(x => x.EmpId).ToList();

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
                //store_location = (from o in store_temp_list
                //                  where o.location_Id == AppSessionState.location_Id && o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                //stringListStoreLoc = store_temp_list.Select(x => x.store_code).ToList();
                if (store_temp_list.Count == 1)
                {
                    store_location = store_temp_list[0].store_code;
                }
                //collectionOrderNo = CollectionViewSource.GetDefaultView(MC.OrderDocNoList);
                //collectionOrderNo.Filter = new Predicate<object>(FilterOrderDocNo);
                //StringListOrderNo = MC.OrderDocNoList.Select(x => x.order_no).ToList();

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
            MasterEntity.mov_tp = "151";
            MasterEntity.doc_cat = "WC";
            MasterEntity.doc_code = "WC";
            MasterEntity.doc_type = "WC";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.vendor = "";
            MasterEntity.PartyId = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.fin_year = "16-17";
            MasterEntity.posting_period = "1";
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.t_status = "001";
            MasterEntity.debcr_ind = false;

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
                foreach (var o in GoodsIssueDetails)
                {
                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        int flag = 0;
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

                        if (o.StockUnt == true && o.id == 0)
                        {
                            var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                            if (paralist.Count > 0)
                            {
                                string[] SkuList = new string[100];     
                                List<string> SkuListt = new List<string>();

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
                
                for (int a = 0; a < dgBatchEntity.Count; a++)
                {
                    for (int b = 0; b < MC.batchList.Count; b++)
                    {
                        if (dgBatchEntity[a].batch_no == MC.batchList[b].batch_no)
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
                        if (GoodsIssueDetails[i].ItemCode == dgBatchEntity[j].ItemCode && GoodsIssueDetails[i].sku == dgBatchEntity[j].sku)
                        {
                            temp = temp + Convert.ToDecimal(dgBatchEntity[j].rec_qty);
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

            
            MasterEntity.XmlDataDocument_MM_T001 = objSerialization.ObjectToXML(GoodsIssueDetails);
            MasterEntity.XmlDataDocument_MM_T001_B = objSerialization.ObjectToXML(dgBatchEntity);
            this.MasterEntity.EndEdit();

            if (Validation() == true)
            {
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
            GoodsIssueDetails.Clear();
            MoveFlag = true;
            _dataGridCollection.Refresh();
            MasterEntity = new MM_T001();
            DefaultValues();
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.ValidateAsync().Wait();
            dgBatchEntity = new ObservableCollection<MM_T001_B>();

            var Collection = (from o in MC.OrderDocNoList where o.doc_cat == "WC" select o).ToList();
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
                DataGridCollection.Refresh();
                parameter = false;
                MoveFlag = true;
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
            FlipGridData = FlipGridData;
            MasterEntity = MasterEntity;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
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

        #endregion
    }
}
